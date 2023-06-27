import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { IAddress } from '../address.interface';
import { AddressService } from '../address.service';
import { MatSort } from '@angular/material/sort';
import { SelectionModel } from '@angular/cdk/collections';
import { MatIconRegistry } from '@angular/material/icon';
import { DomSanitizer } from '@angular/platform-browser';
import { MatDialog } from '@angular/material/dialog';
import { EditAddressDialogComponent } from '../edit-address-dialog/edit-address-dialog.component';
import { IconType } from 'src/app/shared/iconType.enum';
import { IconHelper } from 'src/app/shared/iconHelper';
import { UseIcon } from 'src/app/shared/useIcon.interface';
import { Message } from 'src/app/shared/message.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-address-list',
  templateUrl: './address-list.component.html',
  styleUrls: ['./address-list.component.scss']
})
export class AddressListComponent implements OnInit, UseIcon {
  // Data Properties
  dataSource: any;
  addresses: IAddress[] = [];

  // Sort Properties
  multiSelection: boolean = true;
  initialSelection: [] = [];
  selection = new SelectionModel<IAddress>(this.multiSelection, this.initialSelection);

  @ViewChild(MatSort) sort: MatSort = new MatSort;
  successMessage: Message|null = null;
  errorMessage: Message|null = null;

  // Static data
  displayedColumns : string[] = ['select' ,'id', 'zipCode', 'city', 'street', 'houseNumber', 'stateName', 'countryName', 'detailsIcon', 'editIcon', 'deleteIcon'];
  iconType = IconType;
  iconTypes: IconType[] =  [
    IconType.Create,
    IconType.Delete,
    IconType.Details,
    IconType.Edit
  ];

  constructor(
    private addressService: AddressService,
    public matIconRegistry: MatIconRegistry,
    public domSanitizer: DomSanitizer,
    private dialog: MatDialog,
    private router: Router)
  {
    IconHelper.registerIcons(this.iconTypes, this.matIconRegistry, this.domSanitizer);
    this.readRouterParameters();
  }

  readRouterParameters(): void {
    this.successMessage = this.router.getCurrentNavigation()?.extras?.queryParams?.['successMessage'];
    this.errorMessage = this.router.getCurrentNavigation()?.extras?.queryParams?.['errorMessage'];
  }

  ngOnInit(): void {
    this.addressService
      .getAll()
      .subscribe(data => {
        this.addresses = data;
        this.dataSource = new MatTableDataSource(data);
        this.dataSource.sort = this.sort;
    });

    this.addressService.addressesChanged.subscribe(data => {
      this.addresses = data;
      this.dataSource = new MatTableDataSource(data);
      this.dataSource.sort = this.sort;
    });
  }

  onToggleAllSelection() : void {
    this.addresses.forEach(address => {
      this.selection.toggle(address);
    });
  }

  onAddressToggleSelection(address: IAddress) : void {
    this.selection.toggle(address);
  }

  openEditDialog(address: IAddress) : void {
    this.dialog.open(EditAddressDialogComponent, { data: address});
  }

  async onDeleteAddress(addressId: number): Promise<void> {
    this.addressService.delete(addressId).subscribe();
  }

  delay(ms: number) {
    return new Promise( resolve => setTimeout(resolve, ms) );
  }
}
 