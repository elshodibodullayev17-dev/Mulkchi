const fs = require('fs')
const base =
	'c:/Bitiruv malakaviy ishi/Mulkchi/mulkchi-frontend/src/app/pages/properties/property-list/'

const html = `<div class="list-page">
  <!-- Search Header -->
  <div class="search-header">
    <div class="search-bar">
      <div class="search-input-wrap">
        <span class="icon">&#128269;</span>
        <input type="text" placeholder="Mulk qidirish..." [(ngModel)]="searchQuery" (keyup.enter)="applyFilters()">
      </div>
      <div class="location-wrap">
        <span class="icon">&#128205;</span>
        <input type="text" placeholder="Shahar yoki tuman" [(ngModel)]="filterCity" (keyup.enter)="applyFilters()">
      </div>
      <button class="search-btn" (click)="applyFilters()">Qidirish</button>
    </div>
  </div>

  <div class="list-container">
    <!-- Sidebar Filters -->
    <aside class="filters-sidebar">
      <div class="filters-header">
        <h3>&#128288; Filtrlar</h3>
        <button class="clear-btn" (click)="clearFilters()">Tozalash</button>
      </div>

      <div class="filter-section">
        <label>E'lon turi</label>
        <div class="toggle-group">
          <button class="toggle-btn" [class.active]="filterListingType === ''" (click)="setListingType('')">Hammasi</button>
          <button class="toggle-btn" [class.active]="filterListingType === ListingType.Rent" (click)="setListingType(ListingType.Rent)">Ijara</button>
          <button class="toggle-btn" [class.active]="filterListingType === ListingType.Sale" (click)="setListingType(ListingType.Sale)">Sotish</button>
        </div>
      </div>

      <div class="filter-section">
        <label>Narx oralig'i (UZS)</label>
        <div class="price-range">
          <input type="number" placeholder="Min" [(ngModel)]="filterMinPrice">
          <span>—</span>
          <input type="number" placeholder="Max" [(ngModel)]="filterMaxPrice">
        </div>
      </div>

      <div class="filter-section">
        <label>Xonalar soni</label>
        <div class="chips-group">
          <button class="chip" [class.active]="filterBedrooms === null" (click)="setBedrooms(null)">Barchasi</button>
          <button class="chip" [class.active]="filterBedrooms === 1" (click)="setBedrooms(1)">1</button>
          <button class="chip" [class.active]="filterBedrooms === 2" (click)="setBedrooms(2)">2</button>
          <button class="chip" [class.active]="filterBedrooms === 3" (click)="setBedrooms(3)">3</button>
          <button class="chip" [class.active]="filterBedrooms === 4" (click)="setBedrooms(4)">4+</button>
        </div>
      </div>

      <button class="filter-btn" (click)="applyFilters()">Filtrlarni qo'llash</button>
    </aside>

    <!-- Main Content -->
    <main class="list-main">
      <div class="list-header">
        <div>
          <h1>Barcha mulklar</h1>
          <span class="count" *ngIf="!isLoading">{{ totalCount }} ta e'lon topildi</span>
        </div>
        <div class="sort-row">
          <select [(ngModel)]="sortBy" (change)="applyFilters()">
            <option value="">Saralash</option>
            <option value="price_asc">Narx: Past &#8594; Yuqori</option>
            <option value="price_desc">Narx: Yuqori &#8594; Past</option>
            <option value="newest">Eng yangi</option>
          </select>
        </div>
      </div>

      <app-loading-spinner *ngIf="isLoading"></app-loading-spinner>

      <ng-container *ngIf="!isLoading">
        <p class="empty-state" *ngIf="properties.length === 0">
          Mulklar topilmadi. Filtrlarni o'zgartiring.
        </p>

        <div class="properties-grid" *ngIf="properties.length > 0">
          <app-property-card
            *ngFor="let property of properties"
            [property]="property">
          </app-property-card>
        </div>

        <!-- Pagination -->
        <div class="pagination" *ngIf="totalPages > 1">
          <button class="page-btn" [disabled]="currentPage === 1" (click)="goToPage(currentPage - 1)">&#8592;</button>
          <button
            class="page-btn"
            *ngFor="let page of pages"
            [class.active]="page === currentPage"
            (click)="goToPage(page)">
            {{ page }}
          </button>
          <button class="page-btn" [disabled]="currentPage === totalPages" (click)="goToPage(currentPage + 1)">&#8594;</button>
        </div>
      </ng-container>
    </main>
  </div>
</div>
`

const ts = `import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, ActivatedRoute } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { PropertyService } from '../../../core/services/property.service';
import { Property, PropertyFilter, ListingType } from '../../../core/models/property.models';
import { PropertyCardComponent } from '../../../shared/components/property-card/property-card.component';
import { LoadingSpinnerComponent } from '../../../shared/components/loading-spinner/loading-spinner.component';

@Component({
  selector: 'app-property-list',
  standalone: true,
  imports: [CommonModule, RouterModule, FormsModule, PropertyCardComponent, LoadingSpinnerComponent],
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.scss']
})
export class PropertyListComponent implements OnInit {
  private readonly propertyService = inject(PropertyService);
  private readonly route = inject(ActivatedRoute);

  readonly ListingType = ListingType;
  properties: Property[] = [];
  totalCount = 0;
  isLoading = false;
  currentPage = 1;
  pageSize = 12;

  // Filters
  searchQuery = '';
  filterCity = '';
  filterListingType: ListingType | '' = '';
  filterMinPrice: number | null = null;
  filterMaxPrice: number | null = null;
  filterBedrooms: number | null = null;
  sortBy = '';

  get totalPages(): number {
    return Math.ceil(this.totalCount / this.pageSize);
  }

  get pages(): number[] {
    return Array.from({ length: this.totalPages }, (_, i) => i + 1);
  }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.filterCity = params['city'] ?? '';
      this.filterListingType = params['listingType'] ?? '';
      this.filterBedrooms = params['bedrooms'] ? +params['bedrooms'] : null;
      this.loadProperties();
    });
  }

  loadProperties(): void {
    this.isLoading = true;
    const filter: PropertyFilter = { page: this.currentPage, pageSize: this.pageSize };
    if (this.filterCity) filter.city = this.filterCity;
    if (this.filterListingType) filter.listingType = this.filterListingType as ListingType;
    if (this.filterMinPrice != null) filter.minPrice = this.filterMinPrice;
    if (this.filterMaxPrice != null) filter.maxPrice = this.filterMaxPrice;
    if (this.filterBedrooms != null) filter.bedrooms = this.filterBedrooms;

    this.propertyService.getAll(filter).subscribe({
      next: (result) => {
        this.properties = result.items;
        this.totalCount = result.totalCount;
        this.isLoading = false;
      },
      error: () => { this.isLoading = false; }
    });
  }

  applyFilters(): void {
    this.currentPage = 1;
    this.loadProperties();
  }

  clearFilters(): void {
    this.searchQuery = '';
    this.filterCity = '';
    this.filterListingType = '';
    this.filterMinPrice = null;
    this.filterMaxPrice = null;
    this.filterBedrooms = null;
    this.sortBy = '';
    this.applyFilters();
  }

  setListingType(type: ListingType | ''): void {
    this.filterListingType = type;
  }

  setBedrooms(count: number | null): void {
    this.filterBedrooms = count;
  }

  goToPage(page: number): void {
    if (page >= 1 && page <= this.totalPages) {
      this.currentPage = page;
      this.loadProperties();
      window.scrollTo({ top: 0, behavior: 'smooth' });
    }
  }
}
`

fs.writeFileSync(base + 'property-list.component.html', html)
fs.writeFileSync(base + 'property-list.component.ts', ts)
console.log('HTML lines:', html.split('\n').length)
console.log('TS lines:', ts.split('\n').length)
console.log('Done!')
