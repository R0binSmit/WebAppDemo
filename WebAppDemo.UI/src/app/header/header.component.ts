import { Component, EventEmitter, Output } from '@angular/core';
import { Feature } from '../shared/feature.enum';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
  @Output() featureSelection = new EventEmitter<Feature>();
  features = Feature;

  onNavigate(featureName: Feature) {
    this.featureSelection.emit(featureName);
  }
}
