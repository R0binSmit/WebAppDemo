import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Address } from '../address.model';
import { CountryService } from 'src/app/countries/country.service';
import { StateService } from 'src/app/states/state.service';
import { Country } from 'src/app/countries/country.model';
import { State } from 'src/app/states/state.model';
import { AddressService } from '../address.service';
import { UpdateAddressDto } from './updateAddress.model';

@Component({
  selector: 'app-edit-address-dialog',
  templateUrl: './edit-address-dialog.component.html',
  styleUrls: ['./edit-address-dialog.component.scss']
})
export class EditAddressDialogComponent implements OnInit {
  dialogRef: MatDialogRef<EditAddressDialogComponent>;

  // Data
  address: Address;
  countryService: CountryService;
  addressService: AddressService;
  countries: Country[] = [];
  stateService: StateService;
  states: State[] = [];

  constructor(
    dialogRef: MatDialogRef<EditAddressDialogComponent>,
    @Inject(MAT_DIALOG_DATA) data: Address,
    countryService: CountryService,
    stateService: StateService,
    addressService: AddressService)
  {
    this.countryService = countryService;
    this.stateService = stateService;
    this.addressService = addressService;
    this.dialogRef = dialogRef;
    this.address = data;
  }

  ngOnInit(): void {
    this.countryService.getAll().subscribe(data => {
      this.countries = data;
    })

    this.stateService
      .getByCountryId(this.address.state.country.id)
      .subscribe(data => {
        this.states = data;
    });
  }

  onChangeCountry(countryId: number) {
    this.stateService
      .getByCountryId(countryId)
      .subscribe(data => {
        this.states = data;
    });
  }

  updateAddress(address: Address) : void {
    let updateAddressDto = new UpdateAddressDto(
      address.id, address.state.id, address.city,
      address.street, address.zipCode, address.houseNumber,
      address.houseNumberAddition
    );

    this.addressService
      .update(updateAddressDto)
      .subscribe({
        next: data => { console.log(data); },
        error: error => { console.log(error) }
      });
  }
}
