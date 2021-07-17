import { TestBed } from '@angular/core/testing';

import { RegisterPetService } from './register-pet.service';

describe('RegisterPetService', () => {
  let service: RegisterPetService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RegisterPetService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
