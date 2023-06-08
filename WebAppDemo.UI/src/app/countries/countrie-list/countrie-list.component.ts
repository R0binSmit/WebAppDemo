import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Country } from '../country.model';
import { CountryService } from '../country.service';
import { MatSort } from '@angular/material/sort';
import { SelectionModel } from '@angular/cdk/collections';

@Component({
  selector: 'app-countrie-list',
  templateUrl: './countrie-list.component.html',
  styleUrls: ['./countrie-list.component.scss']
})

export class CountrieListComponent implements OnInit {
  // Data Properties
  dataSource: any;
  countries: Country[] = [];
  countryService: CountryService;

    // Selection Properties
    multiSelection: boolean = true;
    initialSelection: [] = [];
    selection = new SelectionModel<Country>(this.multiSelection, this.initialSelection);

  // Table Configuration
  @ViewChild(MatSort) sort: MatSort;
  displayedColumns: string[] = ["select", "id", "fullName", "shortName"];
  
  constructor(countryService: CountryService ) {
    this.countryService = countryService;
    this.sort = new MatSort();
  }

  ngOnInit(): void {
      this.countryService
        .getAll()
        .subscribe(data => {
          this.countries = data;
          this.dataSource = new MatTableDataSource(this.countries);
          this.dataSource.sort = this.sort;
      });
  }

  onToggleAllSelection() : void {
    debugger;
    this.countries.forEach(country => {
      this.selection.toggle(country);
    });
  }

  onCountryToggleSelection(country: Country) : void {
    this.selection.toggle(country);
  }
}
