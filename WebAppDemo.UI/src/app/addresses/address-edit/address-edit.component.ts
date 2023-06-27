import { Component, ElementRef, ViewChild } from '@angular/core';
import { AddressService } from '../address.service';
import { CountryService } from 'src/app/countries/country.service';
import { StateService } from 'src/app/states/state.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Address } from '../address.model';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Message } from 'src/app/shared/message.model';
import { MessageType } from 'src/app/shared/messageType.enum';
import { HttpErrorResponse } from '@angular/common/http';
import { Country } from 'src/app/countries/country.model';
import { State } from 'src/app/states/state.model';

@Component({
  selector: 'app-address-edit',
  templateUrl: './address-edit.component.html',
  styleUrls: ['./address-edit.component.scss']
})
export class AddressEditComponent {
  addressId: number = 0;
  address: Address = new Address(0, "", "", "", 0, "", 0, null);
  form: FormGroup = new FormGroup([]);
  @ViewChild('zipCodeElement') zipCodeElement!: ElementRef;

  countryId: number|undefined = 0;
  countries: Country[] = [];
  states: State[] = [];

  constructor(
    private addressService: AddressService,
    private countryService: CountryService,
    private stateService: StateService,
    private activatedRoute: ActivatedRoute,
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

  setupBindings(): void {
     this.getZipCodeControl?.valueChanges.subscribe(value => {
      this.address.zipCode = value;
     });

     this.getCityControl?.valueChanges.subscribe(value => {
      this.address.city = value;
     });

     this.getStreetControl?.valueChanges.subscribe(value => {
      this.address.street = value;
     });

     this.getHouseNumberControl?.valueChanges.subscribe(value => {
      this.address.houseNumber = value;
     });

     this.getHouseNumberAdditionControl?.valueChanges.subscribe(value => {
      this.address.houseNumberAddition = value;
     });

     this.getCountryControl?.valueChanges.subscribe(value => {
      this.countryId = value;
     })

     this.getStateControl?.valueChanges.subscribe(value => {
      this.address.stateId = value;
     })
  }

  setInitFormValues(): void {
    this.getZipCodeControl?.setValue(this.address.zipCode);
    this.getCityControl?.setValue(this.address.city);
    this.getStreetControl?.setValue(this.address.street);
    this.getHouseNumberControl?.setValue(this.address.houseNumber);
    this.getHouseNumberAdditionControl?.setValue(this.address.houseNumberAddition);
    this.getCountryControl?.setValue(this.address.state?.country?.id);
    this.getStateControl?.setValue(this.address.state?.id);
  }

  successNavigation(): void {
    let successMessage = new Message(MessageType.Success, "Success", "Address was successfully edited.", true, 10000);
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

  ngOnInit(): void {
    this.addressId = Number(this.activatedRoute.snapshot.paramMap.get('id'));
    this.addressService.get(this.addressId).subscribe(
      data => { this.address = data },
      (response: HttpErrorResponse) => this.errorNavigation(response),
      () => {
        this.setInitFormValues()
        this.countryId = this.address.state?.country?.id;
        this.stateService.getByCountryId(Number(this.countryId)).subscribe(
          data => { this.states = data }
        );
      } 
    );

    this.countryService.getAll().subscribe(
      data => {this.countries = data }
    );

    this.setupBindings();
  }

  ngAfterViewInit(): void {
    this.zipCodeElement.nativeElement.focus();
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

  onCountryChanged(countryId: number): void {
    this.stateService.getByCountryId(countryId).subscribe(
      data => this.states = data
    );
  }

  editAddress(): void {
    if(this.address.id !== 0 && this.form.valid) {
      this.addressService.update(this.address).subscribe(
        null,
        (response: HttpErrorResponse) => this.errorNavigation(response),
        () => this.successNavigation()
      );
    }
  }
}
