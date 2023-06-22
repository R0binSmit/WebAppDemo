import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators  } from '@angular/forms';
import { Router } from '@angular/router';
import { CountryService } from '../country.service';
import { Country } from '../country.model';

@Component({
  selector: 'app-country-create',
  templateUrl: './country-create.component.html',
  styleUrls: ['./country-create.component.scss']
})
export class CountryCreateComponent implements OnInit {
  form: FormGroup = new FormGroup([]);
  @ViewChild('fullNameElement') fullNameElement!: ElementRef;

  constructor(
    public countryService: CountryService,
    private router: Router
  ) {
    this.form = new FormGroup({
      shortName: new FormControl('', [
        Validators.required,
        Validators.minLength(2),
        Validators.maxLength(2)
      ]),
      fullName: new FormControl('', [
        Validators.required
      ])
    });
   }

  get shortName() { return this.form.get('shortName'); }
  get fullName() { return this.form.get('fullName'); }

  ngOnInit(): void {
    this.fullNameElement.nativeElement.focus();
  }

  createCountry(): void {
    if (this.shortName?.valid == true && this.fullName?.valid == true) {
      let country: Country = new Country(0, this.shortName?.value, this.fullName?.value);
      this.countryService.create(country).subscribe(null, null, () => {
        this.router.navigate(['/countries']);
      });
    }
  }
}
