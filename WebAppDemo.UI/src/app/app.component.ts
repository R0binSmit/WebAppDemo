import { Component } from '@angular/core';
import { VacationType } from './models/vacation-type';
import { VacationTypeService } from './services/vacation-type.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'WebAppDemo.UI';
  vacationTypes: VacationType[] = [];

  constructor(private vacationTypeService: VacationTypeService) {
  }

  ngOnInit(): void {
    this.vacationTypeService
      .getAll()
      .subscribe((result: VacationType[]) => (this.vacationTypes = result))
  }
}
