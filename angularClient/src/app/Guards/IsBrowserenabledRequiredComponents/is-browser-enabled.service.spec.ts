import { TestBed } from '@angular/core/testing';

import { IsBrowserEnabledService } from './is-browser-enabled.service';

describe('IsBrowserEnabledService', () => {
  let service: IsBrowserEnabledService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(IsBrowserEnabledService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
