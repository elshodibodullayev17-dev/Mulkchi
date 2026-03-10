import { Component, OnInit } from '@angular/core';
import { CommonModule, DecimalPipe } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { NavbarComponent } from '../../../shared/components/navbar/navbar.component';
import { PropertyService } from '../../../core/services/property.service';
import { BookingService } from '../../../core/services/booking.service';
import { AuthService } from '../../../core/services/auth.service';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule, NavbarComponent, DecimalPipe],
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  properties: any[] = [];
  bookings: any[] = [];
  loading = true;
  activeTab = 'properties';
  // Stats
  totalProperties = 0;
  totalBookings = 0;

  constructor(
    private propertyService: PropertyService,
    private bookingService: BookingService,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    this.loading = true;
    this.propertyService.getProperties(1, 50).subscribe(res => {
      this.properties = res.items;
      this.totalProperties = res.totalCount;
    });
    this.bookingService.getBookings().subscribe(res => {
      this.bookings = res.items;
      this.totalBookings = res.totalCount;
      this.loading = false;
    });
  }

  deleteProperty(id: string) {
    if (!confirm('Mulkni o\'chirishni tasdiqlaysizmi?')) return;
    this.propertyService.deleteProperty(id).subscribe({
      next: () => {
        this.properties = this.properties.filter(p => p.id !== id);
        this.totalProperties--;
      },
      error: (err) => alert('Xatolik: ' + err.message)
    });
  }

  getListingTypeText(type: string): string {
    const map: any = { 'Rent': 'Ijara', 'Sale': 'Sotiladi', 'DailyRent': 'Kunlik' };
    return map[type] || type;
  }

  getPrice(p: any): string {
    if (p.listingType === 'Rent') return `$${p.monthlyRent}/oy`;
    if (p.listingType === 'Sale') return `$${p.salePrice?.toLocaleString()}`;
    return `$${p.pricePerNight}/kun`;
  }

  getStatusClass(status: string): string {
    const map: any = {
      'Pending': 'status-pending',
      'Confirmed': 'status-confirmed',
      'Cancelled': 'status-cancelled',
      'Completed': 'status-completed'
    };
    return map[status] || '';
  }

  getStatusText(status: string): string {
    const map: any = {
      'Pending': 'Kutilmoqda',
      'Confirmed': 'Tasdiqlangan',
      'Cancelled': 'Bekor qilingan',
      'Completed': 'Tugallangan'
    };
    return map[status] || status;
  }
}
