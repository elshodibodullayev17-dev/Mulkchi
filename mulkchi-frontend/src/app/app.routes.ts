import { Routes } from '@angular/router';
import { authGuard } from './core/guards/auth.guard';
import { AnnouncementsComponent } from './pages/announcements/announcements.component';
import { LoginComponent } from './pages/auth/login/login.component';
import { RegisterComponent } from './pages/auth/register/register.component';
import { FavoritesComponent } from './pages/dashboard/favorites/favorites.component';
import { DashboardLayoutComponent } from './pages/dashboard/layout/dashboard-layout.component';
import { MessagesComponent } from './pages/dashboard/messages/messages.component';
import { MyPropertiesComponent } from './pages/dashboard/my-properties/my-properties.component';
import { NotificationsComponent } from './pages/dashboard/notifications/notifications.component';
import { DashboardOverviewComponent } from './pages/dashboard/overview/dashboard-overview.component';
import { PaymentsComponent } from './pages/dashboard/payments/payments.component';
import { RequestsComponent } from './pages/dashboard/requests/requests.component';
import { SettingsComponent } from './pages/dashboard/settings/settings.component';
import { HomeComponent } from './pages/home/home.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { PropertyDetailComponent } from './pages/properties/property-detail/property-detail.component';
import { PropertyListComponent } from './pages/properties/property-list/property-list.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'properties', component: PropertyListComponent },
  { path: 'properties/:id', component: PropertyDetailComponent },
  { path: 'announcements', component: AnnouncementsComponent },
  {
    path: 'dashboard',
    component: DashboardLayoutComponent,
    canActivate: [authGuard],
    children: [
      { path: '', redirectTo: 'overview', pathMatch: 'full' },
      { path: 'overview', component: DashboardOverviewComponent },
      { path: 'my-properties', component: MyPropertiesComponent },
      { path: 'requests', component: RequestsComponent },
      { path: 'payments', component: PaymentsComponent },
      { path: 'favorites', component: FavoritesComponent },
      { path: 'notifications', component: NotificationsComponent },
      { path: 'messages', component: MessagesComponent },
      { path: 'settings', component: SettingsComponent },
    ],
  },
  { path: '**', component: NotFoundComponent },
];
