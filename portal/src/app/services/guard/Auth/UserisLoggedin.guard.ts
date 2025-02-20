import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../../repos/Auth/auth.service';

export const UserisLoggedinGuard: CanActivateFn = (route, state) => {
  let authService = inject(AuthService);
  let router = inject(Router);

  if(authService.isLoggedIn())
    return true
  else{
    router.navigate(['/auth/login'])
    return false;
  }
};
