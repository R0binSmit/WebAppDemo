import { Component, ElementRef, Input, OnChanges, ViewChild, AfterContentInit } from '@angular/core';

@Component({
  selector: 'app-submit-button',
  templateUrl: './submit-button.component.html',
  styleUrls: ['./submit-button.component.scss']
})

export class SubmitButtonComponent implements OnChanges, AfterContentInit  {
  @Input() value: string = "";
  @Input() disabled: boolean = false;
  @ViewChild('submitButton') submitButton!: ElementRef;

  disable(): void {
    let submitButton = this.submitButton?.nativeElement;

    if (submitButton == null) {
      return;
    }

    if (this.disabled) {
      submitButton.setAttribute('disabled', 'disabled');
      submitButton.classList.add('disabled');
    }
    else {
      submitButton.removeAttribute('disabled');
      submitButton.classList.remove('disabled');
    }
  }
  
  ngOnChanges(): void {
    this.disable();
  }

  ngAfterContentInit(): void {
    this.disable();
  }
}
