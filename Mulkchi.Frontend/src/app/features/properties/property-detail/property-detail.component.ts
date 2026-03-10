import { Component, OnInit } from '@angular/core';
import { CommonModule, DecimalPipe } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { NavbarComponent } from '../../../shared/components/navbar/navbar.component';
import { PropertyService } from '../../../core/services/property.service';
import { BookingService } from '../../../core/services/booking.service';
import { AuthService } from '../../../core/services/auth.service';

@Component({
  selector: 'app-property-detail',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule, NavbarComponent, DecimalPipe],
  templateUrl: './property-detail.component.html',
  styleUrls: ['./property-detail.component.scss']
})
export class PropertyDetailComponent implements OnInit {
  property: any = null;
  loading = true;
  // Booking form
  checkIn = ''; 
  checkOut = '';
  guests = 1;
  bookingLoading = false;
  bookingSuccess = false;
  bookingError = '';

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private propertyService: PropertyService,
    private bookingService: BookingService,
    private authService: AuthService
  ) {}

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    if (!id) { this.router.navigate(['/properties']); return; }
    this.propertyService.getProperty(id).subscribe({
      next: (p) => { this.property = p; this.loading = false; },
      error: () => { this.loading = false; this.router.navigate(['/properties']); }
    });
  }

  getImage(): string {
    if (this.property?.images?.length) return this.property.images[0].url;
    const photos: any = {
      'Apartment': 'https://images.unsplash.com/photo-1545324418-cc1a3fa10c00?w=800',
      'House': 'https://images.unsplash.com/photo-1564013799919-ab600027ffc6?w=800',
      'Office': 'https://images.unsplash.com/photo-1497366216548-37526070297c?w=800'
    };
    return photos[this.property?.type || ''] || 'https://images.unsplash.com/photo-1560448204-e02f11c3d0e2?w=800';
  }

  getPrice(): string {
    if (!this.property) return '';
    if (this.property.listingType === 'Rent') return `$${this.property.monthlyRent}/oy`;
    if (this.property.listingType === 'DailyRent') return `$${this.property.pricePerNight}/kun`;
    return `$${this.property.salePrice?.toLocaleString()}`;
  }

  getAmenities(): string[] {
    if (!this.property) return [];
    const list = [];
    if (this.property.hasWifi) list.push(' Wi-Fi');
    if (this.property.hasParking) list.push(' Parking');
    if (this.property.hasPool) list.push(' Basseyn');
    if (this.property.hasElevator) list.push(' Lift');
    if (this.property.hasAirConditioning) list.push(' Konditsioner');
    if (this.property.hasHeating) list.push(' Isitish');
    if (this.property.hasBalcony) list.push(' Balkon');
    if (this.property.hasGarden) list.push(' Bog\'');
    if (this.property.hasSecurity) list.push(' Xavfsizlik');
    if (this.property.hasMetroNearby) list.push(' Metro yaqin');
    if (this.property.isRenovated) list.push(' Ta\'mirlangan');
    if (this.property.isPetFriendly) list.push(' Hayvonlarga ruxsat');
    return list;
  }

  book() {
    if (!this.authService.isLoggedIn()) {
      this.router.navigate(['/login']);
      return;
    }
    if (!this.checkIn || !this.checkOut) {
      this.bookingError = 'Sana va mehmonlar sonini kiriting';
      return;
    }
    this.bookingLoading = true;
    this.bookingError = '';
    this.bookingService.createBooking({
      propertyId: this.property!.id,
      checkInDate: this.checkIn,
      checkOutDate: this.checkOut,
      guestsCount: this.guests
    }).subscribe({
      next: (res) => {
        this.bookingLoading = false;
        this.bookingSuccess = true;
      },
      error: (err) => {
        this.bookingLoading = false;
        this.bookingError = err?.error?.message || 'Bron qilishda xatolik';
      }
    });
  }

  goToChat() {
    if (!this.authService.isLoggedIn()) {
      this.router.navigate(['/login']);
      return;
    }
    this.router.navigate(['/chat']);
  }
}
