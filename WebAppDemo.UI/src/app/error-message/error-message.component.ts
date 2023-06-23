import { Component, ElementRef, Input, ViewChild } from '@angular/core';
import { IconType } from '../shared/iconType.enum';
import { MatIconRegistry } from '@angular/material/icon';
import { DomSanitizer } from '@angular/platform-browser';
import { IconHelper } from '../shared/iconHelper';

@Component({
  selector: 'app-error-message',
  templateUrl: './error-message.component.html',
  styleUrls: ['./error-message.component.scss']
})
export class ErrorMessageComponent {
  @ViewChild('messageBox') messageBox!: ElementRef; 
  @Input() isVisible: boolean = true;
  @Input() visibilityTime: number = 0;
  @Input() title: string = "Error";
  @Input() description: string = "";
  iconType = IconType;

  get getVisibility(): string { return this.isVisible ? "visibility: visiable" : "visibility: hidden" }

  constructor(iconRegistry: MatIconRegistry, sanitizer: DomSanitizer) {
    IconHelper.registerIcons([IconType.Close], iconRegistry, sanitizer);
  }

  ngOnInit(): void {
    this.setupVisibilityTime();
  }

  setupVisibilityTime(): void {
    if(this.visibilityTime > 0) {
      setTimeout(() => { this.setVisibility(false) }, this.visibilityTime);
    }
  }

  setVisibility(visibility: boolean): void {
    this.isVisible = visibility;
  }
}
