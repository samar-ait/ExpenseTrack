import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { AppComponent } from './app/app.component';
import { provideHttpClient, withFetch } from '@angular/common/http';
import { provideRouter } from '@angular/router';
import { routes } from './app/app.routes';
import { provideAnimations } from '@angular/platform-browser/animations';
import { provideToastr } from 'ngx-toastr';

bootstrapApplication(AppComponent, {
  providers: [
    provideHttpClient(withFetch()), // Enables HTTP requests
    provideRouter(routes), // Enables routing
    provideAnimations(), // Enables animations globally
    provideToastr({
      timeOut: 30000,
      positionClass: 'custom-toast-top',
      preventDuplicates: true,
    }), // Registers Toastr globally
  ],
}).catch((err) => console.error(err));
