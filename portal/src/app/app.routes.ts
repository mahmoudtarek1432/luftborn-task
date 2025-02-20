import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'auth/login'},
  { path: 'auth', loadChildren: () => import('./pages/auth/auth.routes').then(m => m.AUTH_ROUTES) },
];
