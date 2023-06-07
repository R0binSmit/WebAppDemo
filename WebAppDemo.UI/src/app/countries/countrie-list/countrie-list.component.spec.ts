import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CountrieListComponent } from './countrie-list.component';

describe('CountrieListComponent', () => {
  let component: CountrieListComponent;
  let fixture: ComponentFixture<CountrieListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CountrieListComponent]
    });
    fixture = TestBed.createComponent(CountrieListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
