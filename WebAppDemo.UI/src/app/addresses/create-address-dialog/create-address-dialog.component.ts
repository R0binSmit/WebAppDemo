import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CountryService } from 'src/app/countries/country.service';
import { StateService } from 'src/app/states/state.service';
import { AddressService } from '../address.service';
import { CreateAddressDto } from './create-address.model';
import { ICountry } from 'src/app/countries/country.interface';
import { State } from 'src/app/states/state.model';

@Component({
  selector: 'app-create-address-dialog',
  templateUrl: './create-address-dialog.component.html',
  styleUrls: ['./create-address-dialog.component.scss']
})
export class CreateAddressDialogComponent implements OnInit {
  countryService: CountryService;
  stateService: StateService;
  addressService: AddressService;
  
  address: CreateAddressDto;
  countries: ICountry[] = [];
  states: State[] = [];

  constructor(
    countryService: CountryService,
    stateService: StateService,
    addressService: AddressService
    ) {
      this.countryService = countryService;
      this.stateService = stateService;
      this.addressService = addressService;
      this.address = new CreateAddressDto(null, "", "", "", null, "");
    }

  ngOnInit(): void {
    this.countryService.getAll().subscribe(data => {
      this.countries = data;
    });
  }

  onChangeCountry(countryId: number): void {
      this.stateService.getByCountryId(countryId).subscribe(data => {
        this.states = data;
      });
  }

  onCreate(): void {
    this.addressService.create(this.address).subscribe();
  }
}
