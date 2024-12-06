import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes'; // Import the routes from your app.routes.ts file
import { provideHttpClient, withFetch } from '@angular/common/http';

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }), // Enables zone change detection
    provideRouter(routes), // Provides the routing configuration
    provideHttpClient(withFetch()),
  ],
};
