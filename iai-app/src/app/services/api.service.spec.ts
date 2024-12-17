import { TestBed } from '@angular/core/testing';

import { ApiAdService } from './api.ad.service';

describe('ApiService', () => {
  let service: ApiAdService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ApiAdService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
