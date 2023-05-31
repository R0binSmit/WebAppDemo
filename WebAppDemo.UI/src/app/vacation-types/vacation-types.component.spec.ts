import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VacationTypesComponent } from './vacation-types.component';

describe('VacationTypesComponent', () => {
  let component: VacationTypesComponent;
  let fixture: ComponentFixture<VacationTypesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [VacationTypesComponent]
    });
    fixture = TestBed.createComponent(VacationTypesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
