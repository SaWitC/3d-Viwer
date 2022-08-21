import { TestBed } from '@angular/core/testing';

import { RequiredDataService } from './required-data.service';

describe('RequiredDataService', () => {
  let service: RequiredDataService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RequiredDataService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
