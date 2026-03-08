import { CommonModule } from '@angular/common';
import { Component, HostListener, inject, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ListingType } from '../../../core/models/property.models';
import { AuthService } from '../../../core/services/auth.service';
import { NotificationService } from '../../../core/services/notification.service';
import { ThemeToggleComponent } from '../theme-toggle/theme-toggle.component';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule, RouterModule, ThemeToggleComponent],
  template: `
    <header class="navbar" [class.scrolled]="isScrolled">
      <nav class="nav-container">
        <!-- Logo -->
        <a routerLink="/" class="nav-logo">
          <span class="logo-text">Mulkchi</span>
          <span class="logo-dot">.</span>
        </a>

        <!-- Desktop Links -->
        <ul class="nav-links">
          <li>
            <a routerLink="/properties" routerLinkActive="active">Mulklar</a>
          </li>
          <li>
            <a
              routerLink="/properties"
              [queryParams]="{ listingType: ListingType.Rent }"
              routerLinkActive="active"
              >Ijara</a
            >
          </li>
          <li>
            <a
              routerLink="/properties"
              [queryParams]="{ listingType: ListingType.Sale }"
              routerLinkActive="active"
              >Sotish</a
            >
          </li>
          <li>
            <a routerLink="/announcements" routerLinkActive="active"
              >E'lonlar</a
            >
          </li>
        </ul>

        <!-- Desktop Actions -->
        <div class="nav-actions">
          <app-theme-toggle />

          <ng-container *ngIf="!isLoggedIn; else loggedInTpl">
            <a routerLink="/login" class="nav-btn nav-btn--ghost">Kirish</a>
            <a routerLink="/register" class="nav-btn nav-btn--primary"
              >Ro'yxatdan o'tish</a
            >
          </ng-container>

          <ng-template #loggedInTpl>
            <a
              routerLink="/dashboard/notifications"
              class="notif-bell"
              title="Bildirishnomalar"
            >
              🔔
              <span class="notif-count" *ngIf="notifCount > 0">{{
                notifCount
              }}</span>
            </a>
            <div class="user-menu" (click)="toggleDropdown()">
              <div class="avatar">{{ getUserInitial() }}</div>
              <span class="chevron">▾</span>
              <div class="dropdown" *ngIf="showDropdown">
                <a
                  routerLink="/dashboard"
                  class="dropdown-item"
                  (click)="showDropdown = false"
                >
                  📊 Dashboard
                </a>
                <div class="divider"></div>
                <button class="dropdown-item logout-btn" (click)="logout()">
                  🚪 Chiqish
                </button>
              </div>
            </div>
          </ng-template>
        </div>

        <!-- Mobile Row: theme + hamburger -->
        <div class="mobile-row">
          <app-theme-toggle />
          <button
            class="mobile-menu-btn"
            (click)="toggleMobileMenu()"
            type="button"
            aria-label="Menu"
          >
            <span [class.open]="showMobileMenu"></span>
            <span [class.open]="showMobileMenu"></span>
            <span [class.open]="showMobileMenu"></span>
          </button>
        </div>
      </nav>

      <!-- Mobile Menu -->
      <div class="mobile-menu" [class.open]="showMobileMenu">
        <a routerLink="/properties" (click)="showMobileMenu = false">Mulklar</a>
        <a routerLink="/announcements" (click)="showMobileMenu = false"
          >E'lonlar</a
        >
        <div class="mobile-divider"></div>
        <a
          routerLink="/login"
          *ngIf="!isLoggedIn"
          (click)="showMobileMenu = false"
          class="nav-btn nav-btn--ghost mobile-full"
          >Kirish</a
        >
        <a
          routerLink="/register"
          *ngIf="!isLoggedIn"
          (click)="showMobileMenu = false"
          class="nav-btn nav-btn--primary mobile-full"
          >Ro'yxatdan o'tish</a
        >
        <a
          routerLink="/dashboard"
          *ngIf="isLoggedIn"
          (click)="showMobileMenu = false"
          >Dashboard</a
        >
        <button *ngIf="isLoggedIn" (click)="logout()" class="mobile-logout">
          Chiqish
        </button>
      </div>
    </header>
  `,
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent implements OnInit {
  private readonly authService = inject(AuthService);
  private readonly notificationService = inject(NotificationService);
  readonly ListingType = ListingType;
  isLoggedIn = false;
  isScrolled = false;
  showDropdown = false;
  showMobileMenu = false;
  notifCount = 0;

  ngOnInit(): void {
    this.isLoggedIn = this.authService.isLoggedIn();
    if (this.isLoggedIn) {
      this.loadNotifCount();
    }
  }

  loadNotifCount(): void {
    this.notificationService.getAll(1, 50).subscribe({
      next: (result) => {
        this.notifCount = result.items.filter((n) => !n.isRead).length;
      },
      error: () => {},
    });
  }

  @HostListener('window:scroll')
  onScroll(): void {
    this.isScrolled = window.scrollY > 20;
  }

  getUserInitial(): string {
    return 'U';
  }

  toggleDropdown(): void {
    this.showDropdown = !this.showDropdown;
  }

  toggleMobileMenu(): void {
    this.showMobileMenu = !this.showMobileMenu;
  }

  logout(): void {
    this.authService.logout();
    this.isLoggedIn = false;
    this.showDropdown = false;
  }
}
