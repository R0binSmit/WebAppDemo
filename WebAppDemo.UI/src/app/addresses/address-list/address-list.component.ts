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

@Component({
  selector: 'app-address-list',
  templateUrl: './address-list.component.html',
  styleUrls: ['./address-list.component.scss']
})
export class AddressListComponent implements OnInit {
  // Data Properties
  dataSource: any;
  addresses: Address[] = [];
  addressService: AddressService;

  // Sort Properties
  multiSelection: boolean = true;
  initialSelection: [] = [];
  selection = new SelectionModel<Address>(this.multiSelection, this.initialSelection);

  @ViewChild(MatSort) sort: MatSort = new MatSort;
  displayedColumns : string[] = ['select' ,'id', 'zipCode', 'city', 'street', 'houseNumber', 'stateName', 'countryName', 'editIcon'];
  dialog: MatDialog;

  constructor(addressService: AddressService, iconRegistry: MatIconRegistry, sanitizer: DomSanitizer, matDialog: MatDialog) {
    iconRegistry.addSvgIcon('edit', sanitizer.bypassSecurityTrustResourceUrl('assets/svg/edit.svg'));
    this.addressService = addressService;
    this.dialog = matDialog;
  }

  ngOnInit(): void {
    this.addressService
      .getAll()
      .subscribe(data => {
        this.addresses = data;
        this.dataSource = new MatTableDataSource(data);
        this.dataSource.sort = this.sort;
      })
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
}
