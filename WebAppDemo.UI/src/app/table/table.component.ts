import { Component, Input } from '@angular/core';
import { TableHeaderItem } from './table-header-item';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss']
})
export class TableComponent {
  @Input() tableHeaderItems: TableHeaderItem[] = [];
  @Input() data: object[] = [];

  constructor() {
  }

  getPropertieValue(object: any, dataPropertieName: string ): string {
    return object[dataPropertieName];
  }

  getTrStyle(index: number): string {
    return index % 2 == 0 ? "bg-white" : "bg-gray-50";
  }
}
