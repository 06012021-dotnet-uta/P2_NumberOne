import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AggressionComponent } from './aggression.component';

describe('AggressionComponent', () => {
  let component: AggressionComponent;
  let fixture: ComponentFixture<AggressionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AggressionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AggressionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
