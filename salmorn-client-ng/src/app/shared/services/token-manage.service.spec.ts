import { TestBed, inject } from '@angular/core/testing';

import { TokenManageService } from './token-manage.service';

describe('TokenManageService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TokenManageService]
    });
  });

  it('should be created', inject([TokenManageService], (service: TokenManageService) => {
    expect(service).toBeTruthy();
  }));
});
