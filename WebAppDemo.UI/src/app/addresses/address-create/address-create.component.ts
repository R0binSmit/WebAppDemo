import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AddressService } from '../address.service';
import { Router } from '@angular/router';
import { CountryService } from 'src/app/countries/country.service';
import { StateService } from 'src/app/states/state.service';
import { IState } from 'src/app/states/state.inteface';
import { Country } from 'src/app/countries/country.model';
import { Address } from '../address.model';
import { HttpErrorResponse } from '@angular/common/http';
import { Message } from 'src/app/shared/message.model';
import { MessageType } from 'src/app/shared/messageType.enum';

@Component({
  selector: 'app-address-create',
  templateUrl: './address-create.component.html',
  styleUrls: ['./address-create.component.scss']
})
export class AddressCreateComponent implements AfterViewInit, OnInit {
  form: FormGroup = new FormGroup([]);
  @ViewChild('zipCodeElement', { static: true}) zipCodeElement!: ElementRef;
  states: IState[] = [];
  countries: Country[] = [];

  constructor(
    private addressService: AddressService,
    private countryService: CountryService,
    private stateService: StateService,
    private router: Router
  ) {
    this.form = new FormGroup({
      zipCode: new FormControl('', [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(10),
        Validators.pattern("^[0-9]*$")
      ]),
      city: new FormControl('', [
        Validators.required,
        Validators.maxLength(150)
      ]),
      street: new FormControl('', [
        Validators.required,
        Validators.maxLength(150)
      ]),
      houseNumber: new FormControl('', [
        Validators.required,
        Validators.maxLength(10)
      ]),
      houseNumberAddition: new FormControl(''),
      country: new FormControl('', [
        Validators.required
      ]),
      state: new FormControl('', [
        Validators.required
      ])
    });
  }

  get getZipCodeControl() { return this.form.get('zipCode'); }
  get getCityControl() { return this.form.get('city'); }
  get getStreetControl() { return this.form.get('street'); }
  get getHouseNumberControl() { return this.form.get('houseNumber'); }
  get getHouseNumberAdditionControl() { return this.form.get('houseNumberAddition'); }
  get getCountryControl() { return this.form.get('country') }
  get getStateControl() { return this.form.get('state'); }

  ngOnInit(): void {
    this.countryService.getAll().subscribe(
      (countries) => { this.countries = countries } 
    );
  }

  ngAfterViewInit(): void {
    this.zipCodeElement.nativeElement.focus();
  }

  /**
   * Update state list when the selected country was changed.
   * @param countryId 
   */
  onCountryChanged(countryId: number): void {
    this.stateService.getByCountryId(countryId).subscribe(
      (states) => { this.states = states; }
    );
  }

  /**
   * Check zipCode value does only contain numbers.
   * Needed to prevent invalid input value.
   * Input type cannot be set to number, otherwise the validators min/max length will not work.
   */
  keyUpZipCode() {
    const regEx = new RegExp("^[0-9]*$")
    let isValid = regEx.test(this.zipCodeElement.nativeElement.value);

    if(isValid == false) {
      let value = this.zipCodeElement.nativeElement.value.substring(0, this.zipCodeElement.nativeElement.value.length - 1);
      this.getZipCodeControl?.setValue(value);
    }
  }

  successNavigation(): void {
    let successMessage = new Message(MessageType.Success, "Success", "Address was successfully created.", true, 10000);
    this.router.navigate(['/addresses'], {
      queryParams: { successMessage }
    });
  }

  errorNavigation(response: HttpErrorResponse): void {
    let errorMessage = new Message(MessageType.Error, "Error", response.error.Description, true, 10000);
    this.router.navigate(['/addresses'], {
      queryParams: { errorMessage }
    });
  }

  createAddress(): void {
    if(this.form.valid) {
      let address = new Address(
        0,
        this.getZipCodeControl?.value,
        this.getCityControl?.value,
        this.getStreetControl?.value,
        this.getHouseNumberControl?.value,
        this.getHouseNumberAdditionControl?.value,
        this.getStateControl?.value, null
      );

      this.addressService.create(address).subscribe(
        null,
        (response: HttpErrorResponse) =>  this.errorNavigation(response),
        () => this.successNavigation()
      );
    }
  }
}