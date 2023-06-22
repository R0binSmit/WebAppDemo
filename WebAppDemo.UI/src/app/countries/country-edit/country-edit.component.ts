import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { CountryService } from '../country.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { Country } from '../country.model';

@Component({
  selector: 'app-country-edit',
  templateUrl: './country-edit.component.html',
  styleUrls: ['./country-edit.component.scss']
})
export class CountryEditComponent implements OnInit, AfterViewInit {
  countryId: number = 0;
  country: Country = new Country(0, "", "");
  form: FormGroup = new FormGroup([]);
  @ViewChild('fullName') fullName!: ElementRef;

  constructor (
    private countryService: CountryService,
    private router: Router,
    private route: ActivatedRoute
    ) {
      this.form = new FormGroup({
        shortName: new FormControl(),
        fullName: new FormControl()
      });
  }
  ngAfterViewInit(): void {
    this.fullName.nativeElement.focus();
    let fullName = this.getFullName();
    let shortName = this.getShortName();

    if (fullName !== null && shortName !== null) {
      fullName.setValue(this.country.fullName);
      shortName.setValue(this.country.shortName)
    }    
  }

  ngOnInit(): void {
    this.countryId = Number(this.route.snapshot.paramMap.get('id'));
    this.countryService.get(this.countryId).subscribe(data => {
      this.country = data
    });
  }

  getShortName(): AbstractControl<any, any>|null {
    return this.form.get('shortName');
  }

  getFullName(): AbstractControl<any, any>|null {
    return this.form.get('fullName');
  }

  isFormValid(): boolean {
    return this.getShortName()?.valid == true && this.getFullName()?.valid == true;
  }

  onKeyUpShortName(): void {
    this.getShortName()?.setValue(this.getShortName()?.value.toUpperCase());
  }

  editCountry(): void {
    if(this.country.id !== 0) {
      this.countryService.update(this.country).subscribe(
        null, null, () => this.router.navigate(['/countries'])
      );
    }
  }
}
