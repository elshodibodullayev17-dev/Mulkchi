import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, switchMap, throwError } from 'rxjs';
import { AuthService } from '../services/auth.service';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  const router = inject(Router);
  const authService = inject(AuthService);

  return next(req).pipe(
    catchError((error: HttpErrorResponse) => {
      if (error.status === 401) {
        const refreshToken = localStorage.getItem('mulkchi_refresh_token');
        if (refreshToken && !req.url.includes('/auth/refresh')) {
          return authService.refreshToken().pipe(
            switchMap((response) => {
              const retried = req.clone({
                setHeaders: { Authorization: `Bearer ${response.token}` },
              });
              return next(retried);
            }),
            catchError((refreshError) => {
              authService.logout();
              router.navigate(['/login']);
              return throwError(() => refreshError);
            }),
          );
        } else {
          authService.logout();
          router.navigate(['/login']);
        }
      } else if (error.status === 403) {
        console.warn('Access forbidden (403):', error);
      } else if (error.status >= 500) {
        console.error('Server error:', error);
      }
      return throwError(() => error);
    }),
  );
};
