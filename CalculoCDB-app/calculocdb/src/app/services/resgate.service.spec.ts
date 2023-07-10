import { TestBed } from '@angular/core/testing';

import { ResgateService } from './resgate.service';

describe('ResgateService', () => {
  let service: ResgateService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ResgateService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
