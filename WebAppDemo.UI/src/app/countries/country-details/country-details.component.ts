import { Component, Input } from '@angular/core';
import { ICountry } from '../country.interface';

@Component({
  selector: 'app-country-details',
  templateUrl: './country-details.component.html',
  styleUrls: ['./country-details.component.scss']
})
export class CountryDetailsComponent {
  @Input() country: ICountry|null = null;
}
