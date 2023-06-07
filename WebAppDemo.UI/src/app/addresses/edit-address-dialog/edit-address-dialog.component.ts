import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Address } from '../address.model';

@Component({
  selector: 'app-edit-address-dialog',
  templateUrl: './edit-address-dialog.component.html',
  styleUrls: ['./edit-address-dialog.component.scss']
})
export class EditAddressDialogComponent {
  dialogRef: MatDialogRef<EditAddressDialogComponent>;
  address: Address;

  constructor(
    dialogRef: MatDialogRef<EditAddressDialogComponent>,
    @Inject(MAT_DIALOG_DATA) data: Address) 
  {
    this.dialogRef = dialogRef;
    this.address = data;
  }
}
