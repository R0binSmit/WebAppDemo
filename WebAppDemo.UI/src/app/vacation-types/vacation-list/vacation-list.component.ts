import { Component } from '@angular/core';
import { VacationType } from 'src/app/vacation-types/vacation-type';
import { VacationTypeService } from 'src/app/services/vacation-type.service';
import { TableHeaderItem } from 'src/app/table/table-header-item';

@Component({
  selector: 'app-vacation-list',
  templateUrl: './vacation-list.component.html',
  styleUrls: ['./vacation-list.component.scss']
})
export class VacationListComponent {
  private vacationTypeService;
  vacationTypes: VacationType[] = [];
  tableHeaderItems: TableHeaderItem[] = [];

  constructor(vacationTypeService: VacationTypeService) {
    this.vacationTypeService = vacationTypeService;

    this.tableHeaderItems = [
      new TableHeaderItem("id", "No."),
      new TableHeaderItem("name", "Name"),
      new TableHeaderItem("editIcon", "_")
    ]
  }

  ngOnInit(): void {
    this.vacationTypeService
      .getAll()
      .subscribe((result: VacationType[]) => (this.vacationTypes = result));
  }

  getVacationTypes(): object[] {
    return this.vacationTypes;
  }
}
