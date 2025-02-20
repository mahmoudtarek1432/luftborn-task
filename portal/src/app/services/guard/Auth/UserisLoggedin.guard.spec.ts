import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { UserisLoggedinGuard } from './UserisLoggedin.guard';

describe('authGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => UserisLoggedinGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
