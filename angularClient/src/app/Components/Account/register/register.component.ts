import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthServiceService } from '../../../Services/Auth/auth-service.service'
import { RegisterVM } from '../../../Models/Account/RegisterVM/register-vm.model'

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(public auth: AuthServiceService) { }

  ngOnInit(): void {
  }

  Register(form: NgForm) {

    console.log(form)
    var model = new RegisterVM();

    model.Email = form.value.Email;
    model.UserName = form.value.UserName;
    model.Password = form.value.Password;
    model.ConfirmPass = form.value.ConfirmPass;

    const creadentialsreg = {
      Email: form.value.Email,
      userName: form.value.UserName,
      password: form.value.Password
    }
    console.log(creadentialsreg)

    console.log(model);////////////////

    this.auth.Register(model);
  }

}
