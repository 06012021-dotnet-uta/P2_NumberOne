import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PetNavbarComponent } from './pet-navbar.component';

describe('PetNavbarComponent', () => {
  let component: PetNavbarComponent;
  let fixture: ComponentFixture<PetNavbarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PetNavbarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PetNavbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
