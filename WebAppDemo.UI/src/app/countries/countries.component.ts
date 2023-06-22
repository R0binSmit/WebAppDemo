import { Component } from '@angular/core';
import { ICountry } from './country.interface';

@Component({
  selector: 'app-countries',
  templateUrl: './countries.component.html',
  styleUrls: ['./countries.component.scss']
})
export class CountriesComponent {
  selectedCountry: ICountry|null = null;

  onSelectCountry(country: ICountry): void {
    this.selectedCountry = country;
  }
}