import { AfterViewInit, Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatTableModule } from '@angular/material/table'
import { VacationType } from '../vacation-type.model';
import { VacationTypeService } from 'src/app/vacation-types/vacation-type.service';
import { MatSort } from '@angular/material/sort';
import { SelectionModel } from '@angular/cdk/collections';

@Component({
  selector: 'app-vacation-list',
  templateUrl: './vacation-list.component.html',
  styleUrls: ['./vacation-list.component.scss'],
})
export class VacationListComponent implements OnInit {
  // Data Properties
  dataSource: any 
  vacationTypes: VacationType[] = [];
  vacationTypeService: VacationTypeService;  

  // Selection Properties
  multiSelection: boolean = true;
  initialSelection: [] = [];
  selection = new SelectionModel<VacationType>(this.multiSelection, this.initialSelection);

  // Table Configuration
  displayedColumns: string[] = ['select', 'id', 'name' ];
  @ViewChild(MatSort) sort: MatSort;

  constructor(vacationTypeService: VacationTypeService) {
    this.vacationTypeService = vacationTypeService;
    this.sort = new MatSort;
  }

  ngOnInit(): void {
    this.vacationTypeService
      .getAll()
      .subscribe(data => { 
        this.vacationTypes = data;
        this.dataSource = new MatTableDataSource(this.vacationTypes);
        this.dataSource.sort = this.sort;
        }
      );
  }

  onVacationTypeToggleSelection(vacationType: VacationType): void {
    this.selection.toggle(vacationType);
  }

  onToggleAllSelection() : void {
    this.vacationTypes.forEach(vacationType => {
      this.selection.toggle(vacationType);
    });
  }
}