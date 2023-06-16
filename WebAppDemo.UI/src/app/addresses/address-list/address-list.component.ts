import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Address } from '../address.model';
import { AddressService } from '../address.service';
import { MatSort } from '@angular/material/sort';
import { SelectionModel } from '@angular/cdk/collections';
import { MatIconRegistry } from '@angular/material/icon';
import { DomSanitizer } from '@angular/platform-browser';
import { MatDialog } from '@angular/material/dialog';
import { EditAddressDialogComponent } from '../edit-address-dialog/edit-address-dialog.component';
import { CreateAddressDialogComponent } from '../create-address-dialog/create-address-dialog.component';
import { IconType } from 'src/app/shared/iconType.enum';
import { IconHelper } from 'src/app/shared/iconHelper';
import { UseIcon } from 'src/app/shared/useIcon.interface';

@Component({
  selector: 'app-address-list',
  templateUrl: './address-list.component.html',
  styleUrls: ['./address-list.component.scss']
})
export class AddressListComponent implements OnInit, UseIcon {
  // Data Properties
  dataSource: any;
  addresses: Address[] = [];

  // Sort Properties
  multiSelection: boolean = true;
  initialSelection: [] = [];
  selection = new SelectionModel<Address>(this.multiSelection, this.initialSelection);

  @ViewChild(MatSort) sort: MatSort = new MatSort;

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
    public addressService: AddressService,
    public matIconRegistry: MatIconRegistry,
    public domSanitizer: DomSanitizer,
    public dialog: MatDialog) 
  {
    IconHelper.registerIcons(this.iconTypes, this.matIconRegistry, this.domSanitizer);
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

  onAddressToggleSelection(address: Address) : void {
    this.selection.toggle(address);
  }

  openEditDialog(address: Address) : void {
    this.dialog.open(EditAddressDialogComponent, { data: address});
  }

  onOpenCreateDialog(): void {
    this.dialog.open(CreateAddressDialogComponent);
  }

  async onDeleteAddress(addressId: number): Promise<void> {
    this.addressService.delete(addressId).subscribe();
  }

  delay(ms: number) {
    return new Promise( resolve => setTimeout(resolve, ms) );
  }
}
 