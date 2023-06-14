import { Component, Input } from '@angular/core';
import { Message } from './message.model';
import { MessageType } from '../shared/messageType.enum';
import { DomSanitizer } from '@angular/platform-browser';
import { MatIconRegistry } from '@angular/material/icon';

@Component({
  selector: 'app-success-message',
  templateUrl: './success-message.component.html',
  styleUrls: ['./success-message.component.scss']
})
export class SuccessMessageComponent {
  @Input() visible: boolean = false;
  @Input() title: string = "Success";
  @Input() description: string = "";

  constructor(iconRegistry: MatIconRegistry, sanitizer: DomSanitizer) {
    iconRegistry.addSvgIcon('close', sanitizer.bypassSecurityTrustResourceUrl('assets/svg/close.svg'))
  }

  onClose(): void {
    this.visible = false
  }
}
