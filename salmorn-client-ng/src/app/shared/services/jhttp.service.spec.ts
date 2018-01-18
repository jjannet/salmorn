import { TestBed, inject } from '@angular/core/testing';

import { JhttpService } from './jhttp.service';

describe('JhttpService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [JhttpService]
    });
  });

  it('should be created', inject([JhttpService], (service: JhttpService) => {
    expect(service).toBeTruthy();
  }));
});
