import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AuthServiceService } from '../../../Services/Auth/auth-service.service'

@Component({
  selector: 'app-account-login-component',
  templateUrl: './account-login-component.component.html',
  styleUrls: ['./account-login-component.component.css']
})
export class AccountLoginComponentComponent implements OnInit {

  public invalidLogin: boolean = true;
  constructor( http: HttpClient, router: Router, public auth: AuthServiceService) { }

  ngOnInit(): void {
    this.invalidLogin = this.auth.invalidLogin;
  }

  public login(ngForm: NgForm) {
    this.auth.login(ngForm);
  }
}