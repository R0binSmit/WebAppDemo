import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Address } from '../address.model';
import { AddressService } from '../address.service';
import { MatSort } from '@angular/material/sort';
import { SelectionModel } from '@angular/cdk/collections';

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

  // Table Configuration
  @ViewChild(MatSort) sort: MatSort = new MatSort;
  displayedColumns : string[] = ['select' ,'id', 'zipCode', 'city', 'street', 'houseNumber', 'stateName', 'countryName'];

  constructor(addressService: AddressService) {
    this.addressService = addressService;
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

}
