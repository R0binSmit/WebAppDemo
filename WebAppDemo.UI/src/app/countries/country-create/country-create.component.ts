import { AfterViewInit, Component, ElementRef, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators  } from '@angular/forms';
import { Router } from '@angular/router';
import { CountryService } from '../country.service';
import { Country } from '../country.model';
import { Message } from 'src/app/shared/message.model';
import { MessageType } from 'src/app/shared/messageType.enum';
import { HttpErrorResponse } from '@angular/common/http';

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

  /**
   * Navigate back to the country list with an error message.
   * @param response HttpErrorResponse.
   */
  errorNavigation(response: HttpErrorResponse) {
    let errorMessage = new Message(MessageType.Error, "Error", response.error.Description, true, 10000);
    this.router.navigate(['/countries'], {
      queryParams: { errorMessage }
    });
  }

  /**
   * Navigate back to the countr list with a success message.
   */
  successNavigation() {
    let successMessage = new Message(MessageType.Success, "Success", "Country was successfully created.", true, 10000);
    this.router.navigate(['/countries'], {
      queryParams: { successMessage }
    });
  }

  /**
   * Create country and navigate back to country list.
   */
  createCountry(): void {
    if (this.form.valid) {
      let country: Country = new Country(0, this.shortName?.value, this.fullName?.value);

      this.countryService.create(country).subscribe(
        null,
        (response: HttpErrorResponse) => this.errorNavigation(response),
        () => this.successNavigation()
      );
    }
  }
}
