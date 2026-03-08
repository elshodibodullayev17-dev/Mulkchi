import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Message } from '../../../core/models/message.models';
import { AuthService } from '../../../core/services/auth.service';
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
export class MessagesComponent implements OnInit {
  private readonly messageService = inject(MessageService);
  private readonly authService = inject(AuthService);

  currentUserId = this.authService.getUserId() ?? '';
  allMessages: Message[] = [];
  conversations: Conversation[] = [];
  activeConversation: Conversation | null = null;
  newMessage = '';
  isSending = false;
  isLoading = true;

  ngOnInit(): void {
    this.load();
  }

  load(): void {
    this.isLoading = true;
    this.messageService.getAll(1, 100).subscribe({
      next: (result) => {
        this.allMessages = result.items.sort(
          (a, b) =>
            new Date(a.createdDate).getTime() -
            new Date(b.createdDate).getTime(),
        );
        this.buildConversations();
        this.isLoading = false;
      },
      error: () => {
        this.isLoading = false;
      },
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
    }
  }

  selectConversation(conv: Conversation): void {
    this.activeConversation = conv;
  }

  sendMessage(): void {
    if (!this.newMessage.trim() || !this.activeConversation) return;
    this.isSending = true;
    this.messageService
      .create({
        content: this.newMessage.trim(),
        senderId: this.currentUserId,
        receiverId: this.activeConversation.partnerId,
      })
      .subscribe({
        next: (msg) => {
          this.newMessage = '';
          this.isSending = false;
          this.allMessages.push(msg);
          this.buildConversations();
          // Re-select the same conversation
          const updated = this.conversations.find(
            (c) => c.partnerId === this.activeConversation!.partnerId,
          );
          if (updated) this.activeConversation = updated;
        },
        error: () => {
          this.isSending = false;
        },
      });
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
