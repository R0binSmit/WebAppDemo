import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SubmitButtonComponent } from './submit-button/submit-button.component';
import { HeaderComponent } from './header/header.component';
import { VacationListComponent } from './vacation-types/vacation-list/vacation-list.component';
import { VacationItemComponent } from './vacation-types/vacation-item/vacation-item.component';
import { VacationDetailsComponent } from './vacation-types/vacation-details/vacation-details.component';
import { TableComponent } from './table/table.component';

@NgModule({
  declarations: [
    AppComponent,
    SubmitButtonComponent,
    HeaderComponent,
    VacationListComponent,
    VacationItemComponent,
    VacationDetailsComponent,
    TableComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
