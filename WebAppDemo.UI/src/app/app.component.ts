import { Component } from '@angular/core';
import { Feature } from './shared/feature.enum';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'WebAppDemo.UI';
  loadedFeature: Feature = Feature.VacationType;
  features = Feature;

  constructor() {
  }

  onNavigate(feature: Feature) {
    this.loadedFeature = feature;
  }
}
