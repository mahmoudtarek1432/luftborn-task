import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { whenLoggedinGotoDashboardGuard } from '../../guard//Auth/when-loggedin-goto-dashboard.guard';

describe('whenLoggedinGotoDashboardGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => whenLoggedinGotoDashboardGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
