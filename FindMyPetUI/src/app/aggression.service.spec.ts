import { TestBed } from '@angular/core/testing';

import { AggressionService } from './aggression.service';

describe('AggressionService', () => {
  let service: AggressionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AggressionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
