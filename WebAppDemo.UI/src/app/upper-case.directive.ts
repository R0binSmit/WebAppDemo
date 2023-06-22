import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: '[appUpperCase]'
})
export class UpperCaseDirective {

  constructor() { }

  @HostListener('input', ['$event']) onInput($event: any) {
    if($event.target == null || typeof $event.target.value != 'string') {
      return;
    }
    
    $event.target.value = $event.target.value.toUpperCase();
  }
}
