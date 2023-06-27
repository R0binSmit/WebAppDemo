import { SelectionModel } from '@angular/cdk/collections';
import { Component, ElementRef, EventEmitter, Output, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { ICountry } from '../country.interface';
import { CountryService } from '../country.service';
import { MatTableDataSource } from '@angular/material/table';
import { UseIcon } from 'src/app/shared/useIcon.interface';
import { _MatDialogContainerBase } from '@angular/material/dialog';
import { MatIconRegistry } from '@angular/material/icon';
import { DomSanitizer } from '@angular/platform-browser';
import { IconHelper } from 'src/app/shared/iconHelper';
import { IconType } from 'src/app/shared/iconType.enum';
import { Router } from '@angular/router';
import { Message } from 'src/app/shared/message.model';
import { SuccessMessageComponent } from 'src/app/success-message/success-message.component';

@Component({
  selector: 'app-country-list',
  templateUrl: './country-list.component.html',
  styleUrls: ['./country-list.component.scss']
})
export class CountryListComponent implements UseIcon {
    // Data Properties
    dataSource: any;
    countries: ICountry[] = [];
    @Output() selectCountry = new EventEmitter<ICountry>();
  
    // Selection Properties
    multiSelection: boolean = true;
    initialSelection: [] = [];
    selection = new SelectionModel<ICountry>(this.multiSelection, this.initialSelection);
  
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

    // Message
    @ViewChild('successMessageElement')  successMessageComponent!: SuccessMessageComponent;
    successMessage: Message|null = null;
    errorMessage: Message|null = null;

    constructor(
      private countryService: CountryService,
      public matIconRegistry: MatIconRegistry,
      public domSanitizer: DomSanitizer,
      private router: Router
    )
    {
      IconHelper.registerIcons(this.iconTypes, this.matIconRegistry, this.domSanitizer);
      this.readRouterParameters();
    }

    readRouterParameters(): void {
      this.successMessage = this.router.getCurrentNavigation()?.extras?.queryParams?.['successMessage'];
      this.errorMessage = this.router.getCurrentNavigation()?.extras?.queryParams?.['errorMessage'];
    }

    loadAllCountries(): void {
      this.countryService
      .getAll()
      .subscribe(data => {
        this.countries = data;
        this.dataSource = new MatTableDataSource(this.countries);
        this.dataSource.sort = this.sort;
      });
    }
  
    ngOnInit(): void {
      this.loadAllCountries();
    }
  
    onToggleAllSelection() : void {
      this.countries.forEach(country => {
        this.selection.toggle(country);
      });
    }
  
    onCountryToggleSelection(country: ICountry) : void {
      this.selection.toggle(country);
    }

    onSelectCountry(country: ICountry): void {
      this.selectCountry.emit(country);
    }

    async onDeleteCountry(countryId: number): Promise<void> {
      this.countryService.delete(countryId).subscribe(null, null, () => { this.loadAllCountries() });
    }
}
