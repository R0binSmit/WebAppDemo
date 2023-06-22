import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ReactiveFormsModule  } from '@angular/forms';
import { Router } from '@angular/router';
import { CountryService } from '../country.service';
import { Country } from '../country.model';

@Component({
  selector: 'app-country-create',
  templateUrl: './country-create.component.html',
  styleUrls: ['./country-create.component.scss']
})
export class CountryCreateComponent implements AfterViewInit {
  form: FormGroup = new FormGroup([]);
  @ViewChild('fullName') fullName!: ElementRef;

  constructor(
    public countryService: CountryService,
    private router: Router
  ) {
    this.form = new FormGroup({
      shortName: new FormControl(),
      fullName: new FormControl()
    });
   }

  ngAfterViewInit(): void {
    this.fullName.nativeElement.focus();
  }

  getShortName(): AbstractControl<any, any>|null {
    return this.form.get('shortName');
  }

  getFullName(): AbstractControl<any, any>|null {
    return this.form.get('fullName');
  }

  createCountry(): void {
    let shortName = this.getShortName();
    let fullName = this.getFullName();

    if (shortName?.valid == true && fullName?.valid == true) {
      let country: Country = new Country(0, shortName?.value, fullName?.value);
      this.countryService.create(country).subscribe(null, null, () => {
        this.router.navigate(['/countries']);
      });
    }
  }

  isFormValid(): boolean {
    return this.getShortName()?.valid == true && this.getFullName()?.valid == true;
  }

  onKeyUpShortName(): void {
    this.getShortName()?.setValue(this.getShortName()?.value.toUpperCase());
  }
}
