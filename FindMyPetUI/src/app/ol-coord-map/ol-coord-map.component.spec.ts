import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OlCoordMapComponent } from './ol-coord-map.component';

describe('OlCoordMapComponent', () => {
  let component: OlCoordMapComponent;
  let fixture: ComponentFixture<OlCoordMapComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OlCoordMapComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OlCoordMapComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
