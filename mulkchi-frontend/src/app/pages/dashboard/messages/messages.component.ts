import { CommonModule } from '@angular/common';
import { Component, OnDestroy, OnInit, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Subscription } from 'rxjs';
import { Message } from '../../../core/models/message.models';
import { AuthService } from '../../../core/services/auth.service';
import { ChatService } from '../../../core/services/chat.service';
import { MessageService } from '../../../core/services/message.service';

interface Conversation {
  partnerId: string;
  messages: Message[];
  lastMessage: Message;
  unreadCount: number;
}

@Component({
  selector: 'app-messages',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.scss'],
})
export class MessagesComponent implements OnInit, OnDestroy {
  private readonly messageService = inject(MessageService);
  private readonly authService = inject(AuthService);
  private readonly chatService = inject(ChatService);

  private chatSub?: Subscription;
  private typingSub?: Subscription;
  private typingTimeout?: ReturnType<typeof setTimeout>;

  currentUserId = this.authService.getUserId() ?? '';
  allMessages: Message[] = [];
  conversations: Conversation[] = [];
  activeConversation: Conversation | null = null;
  newMessage = '';
  isSending = false;
  isLoading = true;
  isPartnerTyping = false;

  ngOnInit(): void {
    this.load();
  }

  ngOnDestroy(): void {
    this.chatSub?.unsubscribe();
    this.typingSub?.unsubscribe();
    clearTimeout(this.typingTimeout);
    this.chatService.stopConnection();
  }

  load(): void {
    this.isLoading = true;
    this.messageService.getAll(1, 200).subscribe({
      next: (result) => {
        this.allMessages = result.items.sort(
          (a, b) =>
            new Date(a.createdDate).getTime() -
            new Date(b.createdDate).getTime(),
        );
        this.buildConversations();
        this.isLoading = false;
        this.startRealTime();
      },
      error: () => {
        this.isLoading = false;
        this.startRealTime();
      },
    });
  }

  private startRealTime(): void {
    this.chatService.startConnection();

    this.chatSub = this.chatService.messages$.subscribe((realtimeMsgs) => {
      if (realtimeMsgs.length === 0) return;
      const incoming = realtimeMsgs[realtimeMsgs.length - 1];
      // Skip duplicates (history already loaded via HTTP)
      if (this.allMessages.some((m) => m.id === incoming.id)) return;

      this.allMessages.push(incoming);
      const prevPartnerId = this.activeConversation?.partnerId;
      this.buildConversations();

      // Re-select same conversation if it received a new message
      if (prevPartnerId) {
        const updated = this.conversations.find(
          (c) => c.partnerId === prevPartnerId,
        );
        if (updated) {
          this.activeConversation = updated;
          // Auto-mark as read if conversation is open and message is incoming
          if (incoming.senderId === prevPartnerId) {
            this.markMsgAsRead(incoming);
          }
        }
      }

      // Reset typing indicator on new message
      this.isPartnerTyping = false;
    });

    this.typingSub = this.chatService.typing$.subscribe((evt) => {
      this.isPartnerTyping = evt.isTyping;
      if (evt.isTyping) {
        clearTimeout(this.typingTimeout);
        // Auto-clear after 4s if no further events
        this.typingTimeout = setTimeout(
          () => (this.isPartnerTyping = false),
          4000,
        );
      }
    });
  }

  buildConversations(): void {
    const map = new Map<string, Message[]>();
    this.allMessages.forEach((msg) => {
      const partnerId =
        msg.senderId === this.currentUserId ? msg.receiverId : msg.senderId;
      if (!map.has(partnerId)) map.set(partnerId, []);
      map.get(partnerId)!.push(msg);
    });

    this.conversations = Array.from(map.entries())
      .map(([partnerId, messages]) => ({
        partnerId,
        messages,
        lastMessage: messages[messages.length - 1],
        unreadCount: messages.filter(
          (m) => !m.isRead && m.receiverId === this.currentUserId,
        ).length,
      }))
      .sort(
        (a, b) =>
          new Date(b.lastMessage.createdDate).getTime() -
          new Date(a.lastMessage.createdDate).getTime(),
      );

    if (this.conversations.length > 0 && !this.activeConversation) {
      this.activeConversation = this.conversations[0];
      this.markConversationAsRead(this.activeConversation);
    }
  }

  selectConversation(conv: Conversation): void {
    this.activeConversation = conv;
    this.isPartnerTyping = false;
    this.markConversationAsRead(conv);
  }

  private markConversationAsRead(conv: Conversation): void {
    conv.messages
      .filter((m) => !m.isRead && m.receiverId === this.currentUserId)
      .forEach((msg) => this.markMsgAsRead(msg));
  }

  private markMsgAsRead(msg: Message): void {
    if (msg.isRead || msg.receiverId !== this.currentUserId) return;
    // Optimistic update
    msg.isRead = true;
    msg.readAt = new Date().toISOString();
    // Rebuild counters
    if (this.activeConversation) {
      this.activeConversation = {
        ...this.activeConversation,
        unreadCount: this.activeConversation.messages.filter(
          (m) => !m.isRead && m.receiverId === this.currentUserId,
        ).length,
      };
    }
    // Persist to server
    this.messageService.update({ ...msg }).subscribe();
  }

  sendMessage(): void {
    if (!this.newMessage.trim() || !this.activeConversation || this.isSending)
      return;
    const content = this.newMessage.trim();
    this.newMessage = '';
    this.isSending = true;

    // Send via SignalR hub (saves to DB, broadcasts confirmation back)
    this.chatService.sendMessage(this.activeConversation.partnerId, content);

    // Stop typing indicator
    this.chatService.sendTypingIndicator(
      this.activeConversation.partnerId,
      false,
    );
    this.isSending = false;
  }

  onTyping(): void {
    if (!this.activeConversation) return;
    this.chatService.sendTypingIndicator(
      this.activeConversation.partnerId,
      true,
    );
    clearTimeout(this.typingTimeout);
    this.typingTimeout = setTimeout(() => {
      if (this.activeConversation) {
        this.chatService.sendTypingIndicator(
          this.activeConversation.partnerId,
          false,
        );
      }
    }, 2000);
  }

  getShortId(id: string): string {
    return id.substring(0, 8).toUpperCase();
  }

  getTime(dateStr: string): string {
    const d = new Date(dateStr);
    const now = new Date();
    const diffDays = Math.floor(
      (now.getTime() - d.getTime()) / (1000 * 60 * 60 * 24),
    );
    if (diffDays === 0) {
      return d.toLocaleTimeString('uz-UZ', {
        hour: '2-digit',
        minute: '2-digit',
      });
    }
    if (diffDays === 1) return 'Kecha';
    return d.toLocaleDateString('uz-UZ', { day: '2-digit', month: '2-digit' });
  }
}
