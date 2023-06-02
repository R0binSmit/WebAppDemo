import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-submit-button',
  templateUrl: './submit-button.component.html',
  styleUrls: ['./submit-button.component.scss']
})

export class SubmitButtonComponent {
  @Input() value: string = "";

  constructor() {

  }

  ngOnInit(): void {
    
  }
}
