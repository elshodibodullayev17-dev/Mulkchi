import { Injectable, inject } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Message } from '../models/message.models';
import { AuthService } from './auth.service';

export interface TypingEvent {
  connectionId: string;
  isTyping: boolean;
}

@Injectable({ providedIn: 'root' })
export class ChatService {
  private readonly authService = inject(AuthService);
  private hubConnection: signalR.HubConnection | null = null;
  private messagesSubject = new BehaviorSubject<Message[]>([]);
  private typingSubject = new Subject<TypingEvent>();

  readonly messages$: Observable<Message[]> =
    this.messagesSubject.asObservable();
  readonly typing$: Observable<TypingEvent> = this.typingSubject.asObservable();

  startConnection(): void {
    if (this.hubConnection) return;

    const hubUrl = environment.hubUrl;
    const token = this.authService.getToken();

    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(hubUrl, { accessTokenFactory: () => token ?? '' })
      .withAutomaticReconnect()
      .build();

    // Incoming message from another user
    this.hubConnection.on('ReceiveMessage', (message: Message) => {
      const current = this.messagesSubject.getValue();
      this.messagesSubject.next([...current, message]);
    });

    // Confirmation back to sender after sending via hub
    this.hubConnection.on('MessageSent', (message: Message) => {
      const current = this.messagesSubject.getValue();
      this.messagesSubject.next([...current, message]);
    });

    // Typing indicator from conversation partner
    this.hubConnection.on(
      'TypingIndicator',
      (connectionId: string, isTyping: boolean) => {
        this.typingSubject.next({ connectionId, isTyping });
      },
    );

    this.hubConnection
      .start()
      .catch((err) => console.error('SignalR connection error:', err));
  }

  stopConnection(): void {
    if (this.hubConnection) {
      this.hubConnection.stop();
      this.hubConnection = null;
    }
  }

  sendMessage(receiverId: string, content: string): void {
    if (!this.hubConnection) return;
    this.hubConnection
      .invoke('SendMessage', receiverId, content)
      .catch((err) => console.error('SendMessage error:', err));
  }

  sendTypingIndicator(receiverId: string, isTyping: boolean): void {
    if (!this.hubConnection) return;
    this.hubConnection
      .invoke('SendTypingIndicator', receiverId, isTyping)
      .catch(() => {
        /* ignore typing errors */
      });
  }

  clearMessages(): void {
    this.messagesSubject.next([]);
  }
}
