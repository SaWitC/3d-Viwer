import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, MinLengthValidator, NgForm, PatternValidator, Validators } from '@angular/forms';
import { AuthServiceService } from '../../../Services/Auth/auth-service.service'
import { RegisterVM } from '../../../Models/Account/RegisterVM/register-vm.model'
import { ValidationService } from '../../../Services/Validation/validation.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(public auth: AuthServiceService, private validationService: ValidationService, private formBuilder: FormBuilder) { }

  public RegisterGroup: FormGroup;
  public submitted: boolean = false;

  ngOnInit(): void {
    this.RegisterGroup = this.formBuilder.group({

      "Email": new FormControl("",
        [Validators.email,
        Validators.required]),

      "UserName": new FormControl("",
        [Validators.minLength(4),
        Validators.required]),

      "Password": new FormControl("",
        [Validators.minLength(6),
        Validators.required,
        Validators.pattern('^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$')]),

      "ConfirmPass": new FormControl("", [
        Validators.minLength(6),
        Validators.required,
        Validators.pattern('^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$')      ]
      )
    },
      {
        validator: this.validationService.MatchPassword('Password', 'ConfirmPass'),
      }
    );

  }

  get registerFormControls() {
    return this.RegisterGroup.controls;
  }

  Register() {

    this.submitted= true;
    var model = new RegisterVM();

    //model.Email = form.value.Email;
    //model.UserName = form.value.UserName;
    //model.Password = form.value.Password;
    //model.ConfirmPass = form.value.ConfirmPass;

    model.Email = this.RegisterGroup.controls["Email"].value;
    model.UserName = this.RegisterGroup.controls["UserName"].value;
    model.Password = this.RegisterGroup.controls["Password"].value;
    model.ConfirmPass = this.RegisterGroup.controls["ConfirmPass"].value;

    this.auth.Register(model);
  }
}

