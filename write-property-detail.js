const fs = require('fs')
const base =
	'c:/Bitiruv malakaviy ishi/Mulkchi/mulkchi-frontend/src/app/pages/properties/property-detail/'

const html = `<div class="detail-page">
  <app-loading-spinner *ngIf="isLoading"></app-loading-spinner>

  <ng-container *ngIf="!isLoading && property">
    <div class="detail-container">
      <!-- Hero Image -->
      <div class="property-image">
        <div class="image-placeholder">
          <span class="hero-emoji">&#127968;</span>
          <div class="image-overlay">
            <span *ngIf="property.isVerified" class="verified-chip">&#10003; Tasdiqlangan</span>
            <span class="listing-type-chip">{{ getListingTypeLabel(property.listingType) }}</span>
          </div>
        </div>
      </div>

      <div class="detail-content">
        <!-- Main Info -->
        <div class="detail-main">
          <div class="detail-header">
            <div>
              <h1>{{ property.title }}</h1>
              <p class="location">&#128205; {{ property.address }}, {{ property.city }}</p>
            </div>
            <div class="price-block" *ngIf="property.averageRating > 0">
              <span class="rating">&#11088; {{ property.averageRating | number:'1.1-1' }}</span>
            </div>
          </div>

          <div class="price-hero">{{ getPrice() }}</div>

          <!-- Meta -->
          <div class="meta-grid">
            <div class="meta-item">
              <span class="meta-icon">&#128716;</span>
              <span class="meta-label">{{ property.numberOfBedrooms }} xona</span>
            </div>
            <div class="meta-item">
              <span class="meta-icon">&#128703;</span>
              <span class="meta-label">{{ property.numberOfBathrooms }} hammom</span>
            </div>
            <div class="meta-item">
              <span class="meta-icon">&#128207;</span>
              <span class="meta-label">{{ property.area }} m²</span>
            </div>
            <div class="meta-item">
              <span class="meta-icon">&#127968;</span>
              <span class="meta-label">{{ property.type }}</span>
            </div>
          </div>

          <!-- Description -->
          <div class="section">
            <h3>Tavsif</h3>
            <p class="description">{{ property.description }}</p>
          </div>

          <!-- Amenities -->
          <div class="section">
            <h3>Qulayliklar</h3>
            <div class="amenities-grid">
              <span class="amenity" *ngIf="property.hasWifi">&#128310; Wi-Fi</span>
              <span class="amenity" *ngIf="property.hasParking">&#128663; Avtoturargoh</span>
              <span class="amenity" *ngIf="property.hasPool">&#127946; Basseyn</span>
              <span class="amenity" *ngIf="property.hasFurniture">&#129681; Mebel</span>
              <span class="amenity" *ngIf="property.hasAirConditioning">&#10052;&#65039; Konditsioner</span>
              <span class="amenity" *ngIf="property.hasHeating">&#128293; Isitish</span>
              <span class="amenity" *ngIf="property.hasKitchen">&#127859; Oshxona</span>
              <span class="amenity" *ngIf="property.hasWasher">&#129514; Kir yuvish mashina</span>
              <span class="amenity" *ngIf="property.hasTV">&#128250; TV</span>
              <span class="amenity" *ngIf="property.hasElevator">&#128759; Lift</span>
              <span class="amenity" *ngIf="property.hasSecurity">&#128272; Qo'riqlov</span>
              <span class="amenity" *ngIf="property.petsAllowed">&#128062; Uy hayvonlari</span>
            </div>
          </div>

          <!-- Host Info -->
          <div class="section">
            <h3>Mulkdor</h3>
            <div class="host-card">
              <div class="host-avatar">&#128100;</div>
              <div class="host-info">
                <span class="host-name">Mulkdor</span>
                <span class="host-meta">ID: {{ property.hostId.substring(0, 8) }}...</span>
              </div>
            </div>
          </div>

          <!-- Reviews -->
          <div class="section" *ngIf="reviews.length > 0">
            <h3>Sharhlar &#11088; {{ property.averageRating | number:'1.1-1' }}</h3>
            <div class="reviews-list">
              <div class="review-item" *ngFor="let review of reviews">
                <div class="review-header">
                  <span class="reviewer">&#128100; Foydalanuvchi</span>
                  <span class="review-rating">{{ review.overallRating }}/5 &#11088;</span>
                </div>
                <p>{{ review.comment }}</p>
              </div>
            </div>
          </div>
        </div>

        <!-- Request Form Sidebar -->
        <aside class="request-sidebar">
          <div class="request-card">
            <h3>So'rov yuborish</h3>

            <ng-container *ngIf="isLoggedIn; else loginPrompt">
              <form [formGroup]="requestForm" (ngSubmit)="submitRequest()">
                <div class="form-group">
                  <label>Kirish sanasi</label>
                  <input type="date" formControlName="checkInDate">
                </div>
                <div class="form-group">
                  <label>Chiqish sanasi</label>
                  <input type="date" formControlName="checkOutDate">
                </div>
                <div class="form-group">
                  <label>Mehmonlar soni</label>
                  <input type="number" formControlName="guestCount" min="1" [max]="property.maxGuests">
                </div>
                <button type="submit" class="submit-btn" [disabled]="isRequestLoading">
                  {{ isRequestLoading ? 'Yuklanmoqda...' : "So'rov yuborish" }}
                </button>
              </form>
            </ng-container>

            <ng-template #loginPrompt>
              <p class="login-prompt">So'rov yuborish uchun tizimga kiring</p>
              <a routerLink="/login" class="login-btn">Kirish</a>
            </ng-template>
          </div>
        </aside>
      </div>
    </div>
  </ng-container>

  <div class="not-found" *ngIf="!isLoading && !property">
    <p>Mulk topilmadi</p>
    <a routerLink="/properties" class="back-btn">Orqaga qaytish</a>
  </div>
</div>
`

const scss = `.detail-page {
  padding-bottom: 80px;
  background: var(--background);
  min-height: 100vh;
}

.detail-container {
  max-width: 1280px;
  margin: 0 auto;
  padding: 32px 24px;
}

/* ---- Hero Image ---- */
.property-image {
  height: 420px;
  border-radius: 20px;
  overflow: hidden;
  margin-bottom: 40px;
}

.image-placeholder {
  width: 100%;
  height: 100%;
  background: linear-gradient(135deg, #1a1a2e 0%, #16213e 50%, #0f3460 100%);
  display: flex;
  align-items: center;
  justify-content: center;
  position: relative;

  .hero-emoji { font-size: 80px; opacity: 0.4; }

  .image-overlay {
    position: absolute;
    bottom: 20px;
    left: 20px;
    display: flex;
    gap: 8px;

    .verified-chip {
      background: rgba(76,175,130,0.2);
      border: 1px solid rgba(76,175,130,0.4);
      color: var(--success);
      padding: 6px 14px;
      border-radius: 20px;
      font-size: 12px;
      font-weight: 600;
    }

    .listing-type-chip {
      background: rgba(201,168,76,0.2);
      border: 1px solid rgba(201,168,76,0.4);
      color: var(--primary);
      padding: 6px 14px;
      border-radius: 20px;
      font-size: 12px;
      font-weight: 600;
    }
  }
}

/* ---- Layout ---- */
.detail-content {
  display: grid;
  grid-template-columns: 1fr 380px;
  gap: 40px;
  align-items: start;
}

/* ---- Main ---- */
.detail-header {
  display: flex;
  justify-content: space-between;
  align-items: flex-start;
  margin-bottom: 8px;
  gap: 16px;

  h1 {
    font-family: 'Playfair Display', serif;
    font-size: clamp(22px, 4vw, 32px);
    font-weight: 700;
    color: var(--foreground);
    margin-bottom: 8px;
    line-height: 1.25;
  }

  .location {
    font-size: 14px;
    color: var(--muted);
  }

  .rating {
    font-size: 15px;
    font-weight: 600;
    color: var(--foreground);
    background: var(--muted-bg);
    padding: 6px 12px;
    border-radius: 8px;
    white-space: nowrap;
  }
}

.price-hero {
  font-family: 'Playfair Display', serif;
  font-size: 28px;
  font-weight: 700;
  color: var(--primary);
  margin-bottom: 28px;
}

.meta-grid {
  display: grid;
  grid-template-columns: repeat(4, 1fr);
  gap: 12px;
  margin-bottom: 32px;
  padding: 20px;
  background: var(--card);
  border: 1px solid var(--border-color);
  border-radius: 16px;
}

.meta-item {
  display: flex;
  flex-direction: column;
  align-items: center;
  text-align: center;
  gap: 6px;

  .meta-icon { font-size: 22px; }

  .meta-label {
    font-size: 13px;
    color: var(--muted);
    font-weight: 500;
  }
}

.section {
  margin-bottom: 32px;

  h3 {
    font-size: 18px;
    font-weight: 700;
    color: var(--foreground);
    margin-bottom: 16px;
    font-family: 'Playfair Display', serif;
  }
}

.description {
  color: var(--muted);
  line-height: 1.7;
  font-size: 15px;
}

.amenities-grid {
  display: flex;
  flex-wrap: wrap;
  gap: 10px;
}

.amenity {
  padding: 8px 16px;
  background: var(--muted-bg);
  border: 1px solid var(--border-color);
  border-radius: 8px;
  font-size: 13px;
  color: var(--foreground);
}

.host-card {
  display: flex;
  align-items: center;
  gap: 16px;
  padding: 20px;
  background: var(--card);
  border: 1px solid var(--border-color);
  border-radius: 16px;
}

.host-avatar {
  width: 52px;
  height: 52px;
  border-radius: 50%;
  background: var(--muted-bg);
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 24px;
  flex-shrink: 0;
}

.host-info {
  display: flex;
  flex-direction: column;
  gap: 4px;

  .host-name { font-weight: 600; color: var(--foreground); font-size: 15px; }
  .host-meta { font-size: 12px; color: var(--muted); }
}

.reviews-list {
  display: flex;
  flex-direction: column;
  gap: 16px;
}

.review-item {
  padding: 16px;
  background: var(--card);
  border: 1px solid var(--border-color);
  border-radius: 12px;

  p { color: var(--muted); font-size: 14px; line-height: 1.6; margin: 0; }
}

.review-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 8px;

  .reviewer { font-size: 13px; font-weight: 600; color: var(--foreground); }
  .review-rating { font-size: 13px; color: var(--primary); }
}

/* ---- Sidebar ---- */
.request-sidebar {
  position: sticky;
  top: 88px;
}

.request-card {
  background: var(--card);
  border: 1px solid var(--border-color);
  border-radius: 20px;
  padding: 28px;

  h3 {
    font-family: 'Playfair Display', serif;
    font-size: 20px;
    font-weight: 700;
    color: var(--foreground);
    margin-bottom: 24px;
  }
}

.form-group {
  margin-bottom: 16px;

  label {
    display: block;
    font-size: 13px;
    font-weight: 500;
    color: var(--foreground);
    margin-bottom: 6px;
  }

  input {
    width: 100%;
    height: 44px;
    background: var(--background);
    border: 1px solid var(--border-color);
    border-radius: 8px;
    padding: 0 12px;
    color: var(--foreground);
    font-size: 14px;
    box-sizing: border-box;
    transition: border-color 0.2s;

    &:focus { border-color: var(--primary); outline: none; }
  }
}

.submit-btn {
  width: 100%;
  height: 50px;
  background: var(--primary);
  color: #000;
  border: none;
  border-radius: 12px;
  font-size: 15px;
  font-weight: 700;
  cursor: pointer;
  margin-top: 8px;
  transition: background 0.2s;

  &:hover:not(:disabled) { background: var(--primary-hover); }
  &:disabled { opacity: 0.6; cursor: not-allowed; }
}

.login-prompt {
  font-size: 14px;
  color: var(--muted);
  text-align: center;
  margin-bottom: 16px;
}

.login-btn {
  display: block;
  width: 100%;
  height: 50px;
  background: var(--primary);
  color: #000;
  border: none;
  border-radius: 12px;
  font-size: 15px;
  font-weight: 700;
  text-align: center;
  line-height: 50px;
  text-decoration: none;
  transition: background 0.2s;

  &:hover { background: var(--primary-hover); }
}

/* ---- Not Found ---- */
.not-found {
  max-width: 1280px;
  margin: 80px auto;
  padding: 0 24px;
  text-align: center;

  p { font-size: 18px; color: var(--muted); margin-bottom: 24px; }
}

.back-btn {
  display: inline-block;
  padding: 12px 28px;
  border: 1px solid var(--primary);
  color: var(--primary);
  border-radius: 10px;
  text-decoration: none;
  font-size: 14px;
  font-weight: 600;
  transition: all 0.2s;

  &:hover { background: var(--primary); color: #000; }
}

/* ---- Responsive ---- */
@media (max-width: 960px) {
  .detail-content { grid-template-columns: 1fr; }
  .request-sidebar { position: static; }
  .meta-grid { grid-template-columns: repeat(2, 1fr); }
}

@media (max-width: 640px) {
  .property-image { height: 260px; border-radius: 12px; }
  .detail-header h1 { font-size: 22px; }
  .price-hero { font-size: 22px; }
  .meta-grid { grid-template-columns: repeat(2, 1fr); }
}
`

fs.writeFileSync(base + 'property-detail.component.html', html)
fs.writeFileSync(base + 'property-detail.component.scss', scss)
console.log('HTML lines:', html.split('\n').length)
console.log('SCSS lines:', scss.split('\n').length)
console.log('Done!')
