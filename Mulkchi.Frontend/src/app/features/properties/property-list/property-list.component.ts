import { Component, OnInit } from '@angular/core';
import { CommonModule, DecimalPipe } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { NavbarComponent } from '../../../shared/components/navbar/navbar.component';
import { PropertyCardComponent } from '../../../shared/components/property-card/property-card.component';
import { PropertyService } from '../../../core/services/property.service';

@Component({
  selector: 'app-property-list',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule, NavbarComponent, PropertyCardComponent, DecimalPipe],
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.scss']
})
export class PropertyListComponent implements OnInit {
  properties: any[] = [];
  loading = true;
  totalCount = 0;
  totalPages = 0;
  currentPage = 1;
  pageSize = 9;

  // Filters
  filterRegion = '';
  filterType = '';
  filterListing = '';
  filterMinPrice = '';
  filterMaxPrice = '';
  filterBedrooms = '';

  regions = ['Toshkent','Samarqand','Buxoro','Namangan',
    'Andijon','Fargona','Qashqadaryo','Surxondaryo',
    'Xorazm','Navoiy','Jizzax','Sirdaryo'];

  constructor(
    private propertyService: PropertyService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      if (params['region']) this.filterRegion = params['region'];
      if (params['type']) this.filterType = params['type'];
      if (params['listingType']) this.filterListing = params['listingType'];
      this.loadProperties();
    });
  }

  loadProperties() {
    this.loading = true;
    const params: any = {
      pageNumber: this.currentPage,
      pageSize: this.pageSize
    };
    if (this.filterRegion) params['region'] = this.filterRegion;
    if (this.filterType) params['propertyType'] = this.filterType;
    if (this.filterListing) params['listingType'] = this.filterListing;
    if (this.filterMinPrice) params['minPrice'] = +this.filterMinPrice;
    if (this.filterMaxPrice) params['maxPrice'] = +this.filterMaxPrice;
    if (this.filterBedrooms) params['bedrooms'] = +this.filterBedrooms;

    this.propertyService.searchProperties(params).subscribe({
      next: (res) => {
        this.properties = res.items;
        this.totalCount = res.totalCount;
        this.totalPages = res.totalPages;
        this.loading = false;
      },
      error: () => { this.loading = false; }
    });
  }

  applyFilters() {
    this.currentPage = 1;
    this.loadProperties();
  }

  clearFilters() {
    this.filterRegion = '';
    this.filterType = '';
    this.filterListing = '';
    this.filterMinPrice = '';
    this.filterMaxPrice = '';
    this.filterBedrooms = '';
    this.currentPage = 1;
    this.loadProperties();
  }

  goToPage(page: number) {
    if (page >= 1 && page <= this.totalPages) {
      this.currentPage = page;
      this.loadProperties();
      window.scrollTo(0, 0);
    }
  }
}
