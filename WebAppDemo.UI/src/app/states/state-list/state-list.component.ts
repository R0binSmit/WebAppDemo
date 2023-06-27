import { Component, OnInit, ViewChild } from '@angular/core';
import { IState } from '../state.inteface';
import { StateService } from '../state.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { SelectionModel } from '@angular/cdk/collections';

@Component({
  selector: 'app-state-list',
  templateUrl: './state-list.component.html',
  styleUrls: ['./state-list.component.scss']
})
export class StateListComponent implements OnInit {
  // Data Properties
  dataSource: any;
  states: IState[] = [];
  stateService: StateService

  // Select Properties
  multiSelection: boolean = true;
  initiSelection: [] = [];
  selection = new SelectionModel<IState>(this.multiSelection, this.initiSelection);

  // Table Configuration
  @ViewChild(MatSort) sort: MatSort;
  displayedColumns : string[] = ["select", "id", "name", "countryName"]

  constructor(stateService: StateService) {
    this.stateService = stateService;
    this.sort = new MatSort()
  }

  ngOnInit(): void {
    this.stateService
    .getAll()
    .subscribe(data => {
      this.states = data;
      this.dataSource = new MatTableDataSource(this.states);
      this.dataSource.sort = this.sort;
  });
  }

  onToggleAllSelection() : void {
    this.states.forEach(state => {
      this.selection.toggle(state);
    });   
  }

  onStateToggleSelection(state: IState) : void {
    this.selection.toggle(state);
  }
}
