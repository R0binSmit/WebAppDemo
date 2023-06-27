import { AbstractControl, ValidationErrors, Validators } from "@angular/forms";

export class CustomValidators extends Validators {
    public static onlyNumbers(control: AbstractControl): ValidationErrors|null {
        return null;
    }
}