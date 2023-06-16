import { SelectionModel } from '@angular/cdk/collections';
import { Component, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { Country } from '../country.model';
import { CountryService } from '../country.service';
import { MatTableDataSource } from '@angular/material/table';
import { UseIcon } from 'src/app/shared/useIcon.interface';
import { _MatDialogContainerBase } from '@angular/material/dialog';
import { MatIconRegistry } from '@angular/material/icon';
import { DomSanitizer } from '@angular/platform-browser';
import { IconHelper } from 'src/app/shared/iconHelper';
import { IconType } from 'src/app/shared/iconType.enum';

@Component({
  selector: 'app-country-list',
  templateUrl: './country-list.component.html',
  styleUrls: ['./country-list.component.scss']
})
export class CountryListComponent implements UseIcon {
    // Data Properties
    dataSource: any;
    countries: Country[] = [];
  
    // Selection Properties
    multiSelection: boolean = true;
    initialSelection: [] = [];
    selection = new SelectionModel<Country>(this.multiSelection, this.initialSelection);
  
    // Table Configuration
    @ViewChild(MatSort) sort: MatSort = new MatSort();;
    displayedColumns: string[] = ["select", "id", "fullName", "shortName", "detailsIcon", "editIcon", "deleteIcon"];
    iconType = IconType;
    iconTypes: IconType[] = [
      IconType.Create,
      IconType.Delete,
      IconType.Details,
      IconType.Edit
    ]

    constructor(
      public countryService: CountryService,
      public matIconRegistry: MatIconRegistry,
      public domSanitizer: DomSanitizer
    )
    {
      IconHelper.registerIcons(this.iconTypes, this.matIconRegistry, this.domSanitizer);
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
      this.countries.forEach(country => {
        this.selection.toggle(country);
      });
    }
  
    onCountryToggleSelection(country: Country) : void {
      this.selection.toggle(country);
    }
}
