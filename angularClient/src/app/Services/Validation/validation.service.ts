import { Injectable } from '@angular/core';
import { AbstractControl, FormGroup, ValidatorFn } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class ValidationService {

  constructor() { }

  MatchPassword(password: string, confirmpassword: string) {
    return (formGroup: FormGroup)=>{
      const Password = formGroup.controls[password];
      const ConfirmPassword = formGroup.controls[confirmpassword];

      if (!Password || !ConfirmPassword) {
        return null;
      }

      if (ConfirmPassword.errors) {
        return null;
      }

      if (Password.value !== ConfirmPassword.value) {
        ConfirmPassword.setErrors({ passwordMismatch: true });
      }
      else {
        ConfirmPassword.setErrors(null);
      }
      return null;
    }
  }

  //PasswordPatternValidator(): ValidatorFn {
  //  return (control: AbstractControl): { [key: string]: any } => {
  //    if (!control.value) {
  //      return null;
  //    }
  //    const regex = new RegExp('^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$');
  //    const valid = regex.test(control.value);
  //    return valid ? null : { invalidPassword: true };
  //  };
  //}



}
