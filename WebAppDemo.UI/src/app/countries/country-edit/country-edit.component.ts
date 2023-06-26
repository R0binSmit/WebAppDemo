import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { CountryService } from '../country.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Country } from '../country.model';
import { HttpErrorResponse } from '@angular/common/http';
import { MessageType } from 'src/app/shared/messageType.enum';
import { Message } from 'src/app/shared/message.model';

@Component({
  selector: 'app-country-edit',
  templateUrl: './country-edit.component.html',
  styleUrls: ['./country-edit.component.scss']
})
export class CountryEditComponent implements OnInit, AfterViewInit {
  // Setup data properties with init values.
  countryId: number = 0;
  country: Country = new Country(0, "", "");
  form: FormGroup = new FormGroup([]);
  @ViewChild('fullNameElement') fullNameElement!: ElementRef;

  constructor (
    private countryService: CountryService,
    private router: Router,
    private route: ActivatedRoute) 
  {
    // Define From and FormControls. 
    this.form = new FormGroup({
      shortName: new FormControl('', [
          Validators.required,
          Validators.maxLength(2),
          Validators.minLength(2)
        ]
      ),
      fullName: new FormControl('', [
          Validators.required
        ]
      )
    });
  }

  // FormControl Getters.
  get shortName() { return this.form.get('shortName'); }
  get fullName() { return this.form.get('fullName'); }

  /**
   * Setup model binding to FormControls.
   */
  setupBindings(): void {
    this.shortName?.valueChanges.subscribe(value => {
      this.country.shortName = value;
    });

    this.fullName?.valueChanges.subscribe(value => {
      this.country.fullName = value;
    });
  }

  /**
   * Set init values to FormControls by country values.
   * Country values are inited after the ngOnInit function.
   */
  setInitFormValues(): void {
    this.shortName?.setValue(this.country.shortName);
    this.fullName?.setValue(this.country.fullName);
  }

  /**
   * Navigate back to the country list with a success message.
   */
  successNavigation(): void {
    let successMessage = new Message(MessageType.Success, "Success", "Country was successfully edit.", true, 10000);
    this.router.navigate(['/countries'], {
      queryParams: { successMessage }
    });
  }

  /**
   * Navigate back to the country list with a error message.
   * @param response 
   */
  errorNavigation(response: HttpErrorResponse): void {
    let errorMessage = new Message(MessageType.Error, "Error", response.error.Description, true, 10000)
    this.router.navigate(['/countries'], {
      queryParams: { errorMessage }
    });
  }

  /**
   * Loading all data by router parameter and setup FormControl values/bindings.
   * Error loading country data by id => navigate back to country list.
   */
  ngOnInit(): void {
    this.countryId = Number(this.route.snapshot.paramMap.get('id'));

    this.countryService.get(this.countryId).subscribe(
      data => { this.country = data },
      (response: HttpErrorResponse) => this.errorNavigation(response),
      () => this.setInitFormValues()
    );
    this.setupBindings();
  }
  
  ngAfterViewInit(): void {
    this.fullNameElement.nativeElement.focus();
  }
  
  /**
   * Update country by model.
   * Error => navigate back to country list with error message. 
   * Complete => navigate back to country list with out an message.
   */
  editCountry(): void {
    if(this.country.id !== 0) {
      this.countryService.update(this.country).subscribe(
        null,
        (response: HttpErrorResponse) => this.errorNavigation(response),
        () => this.successNavigation()
      );
    }
  }
}
