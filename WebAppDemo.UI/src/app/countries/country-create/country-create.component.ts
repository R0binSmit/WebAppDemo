import { AfterViewInit, Component, ElementRef, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators  } from '@angular/forms';
import { Router } from '@angular/router';
import { CountryService } from '../country.service';
import { Country } from '../country.model';
import { Message } from 'src/app/shared/message.model';
import { MessageType } from 'src/app/shared/messageType.enum';

@Component({
  selector: 'app-country-create',
  templateUrl: './country-create.component.html',
  styleUrls: ['./country-create.component.scss']
})
export class CountryCreateComponent implements AfterViewInit {
  form: FormGroup = new FormGroup([]);
  @ViewChild('fullNameElement', { static: true}) fullNameElement!: ElementRef;

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

  ngAfterViewInit(): void {
    this.fullNameElement.nativeElement.focus();
  }

  createCountry(): void {
    if (this.shortName?.valid == true && this.fullName?.valid == true) {
      let country: Country = new Country(0, this.shortName?.value, this.fullName?.value);
      let successMessage = new Message(MessageType.Success, "Success", "Country was successfully created.", true, 10000);
      this.countryService.create(country).subscribe(null, null, () => {
        this.router.navigate(['/countries'], {
            queryParams: { successMessage }
          }
        );
      });
    }
  }
}
