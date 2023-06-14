// Basic imports
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

// Angular imports
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// Angular Material imports
import { MatTableModule } from '@angular/material/table';
import { MatMenuModule } from '@angular/material/menu';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule} from '@angular/material/select';

// Component imports
import { CountrieListComponent } from './countries/countrie-list/countrie-list.component';
import { StateListComponent } from './states/state-list/state-list.component';
import { AddressListComponent } from './addresses/address-list/address-list.component';
import { EditAddressDialogComponent } from './addresses/edit-address-dialog/edit-address-dialog.component';
import { SubmitButtonComponent } from './submit-button/submit-button.component';
import { HeaderComponent } from './header/header.component';
import { VacationListComponent } from './vacation-types/vacation-list/vacation-list.component';
import { CancelButtonComponent } from './cancel-button/cancel-button.component';
import { SuccessMessageComponent } from './success-message/success-message.component';
import { CreateAddressDialogComponent } from './addresses/create-address-dialog/create-address-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    SubmitButtonComponent,
    VacationListComponent,
    HeaderComponent,
    CountrieListComponent,
    StateListComponent,
    AddressListComponent,
    EditAddressDialogComponent,
    CancelButtonComponent,
    SuccessMessageComponent,
    CreateAddressDialogComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatToolbarModule,
    MatMenuModule,
    MatIconModule,
    MatTooltipModule,
    MatPaginatorModule,
    MatSortModule,
    MatCheckboxModule,
    MatFormFieldModule,
    MatDialogModule,
    MatInputModule,
    FormsModule,
    MatSelectModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
