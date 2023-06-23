import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { MatIconRegistry } from '@angular/material/icon';
import { IconHelper } from '../shared/iconHelper';
import { IconType } from '../shared/iconType.enum';

@Component({
  selector: 'app-success-message',
  templateUrl: './success-message.component.html',
  styleUrls: ['./success-message.component.scss']
})
export class SuccessMessageComponent implements OnInit {
  @ViewChild('messageBox') messageBox!: ElementRef; 
  @Input() isVisible: boolean = true;
  @Input() visibilityTime: number = 0;
  @Input() title: string = "Success";
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