import { Routes } from '@angular/router';
import { UserisLoggedinGuard } from './services/guard/Auth/UserisLoggedin.guard';
import { whenLoggedinGotoDashboardGuard } from './services/guard/Auth/when-loggedin-goto-dashboard.guard';
import { DASHBOARD_ROUTES } from './pages/dashboard/dashboard.routes';
import { DashboardComponent } from './pages/dashboard/dashboardFrame/dashboardFrame.component';

export const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'auth/login'},
  { path: 'auth', loadChildren: () => import('./pages/auth/auth.routes').then(m => m.AUTH_ROUTES), canActivate: [whenLoggedinGotoDashboardGuard] },
  { path: 'dashboard',
    component: DashboardComponent,
    children: DASHBOARD_ROUTES,
    canActivate: [UserisLoggedinGuard]
  }
];
