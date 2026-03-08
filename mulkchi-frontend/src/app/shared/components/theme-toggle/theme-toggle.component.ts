import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { ThemeService } from '../../../core/services/theme.service';

@Component({
  selector: 'app-theme-toggle',
  standalone: true,
  imports: [CommonModule],
  template: `
    <button
      class="theme-toggle"
      (click)="themeService.toggle()"
      [title]="themeService.isDark() ? 'Kunduzgi rejim' : 'Tungi rejim'"
      type="button"
    >
      <span class="toggle-icon" *ngIf="themeService.isDark()">☀️</span>
      <span class="toggle-icon" *ngIf="!themeService.isDark()">🌙</span>
    </button>
  `,
  styles: [
    `
      .theme-toggle {
        background: var(--muted-bg);
        border: 1px solid var(--border-color);
        border-radius: 8px;
        width: 38px;
        height: 38px;
        display: flex;
        align-items: center;
        justify-content: center;
        cursor: pointer;
        transition: all 0.2s;
        font-size: 16px;

        &:hover {
          background: var(--border-color);
          transform: scale(1.05);
        }
      }

      .toggle-icon {
        line-height: 1;
      }
    `,
  ],
})
export class ThemeToggleComponent {
  readonly themeService = inject(ThemeService);
}
