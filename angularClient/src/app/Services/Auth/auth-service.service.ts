import { Injectable } from '@angular/core';
import { JwtHelperService } from "@auth0/angular-jwt"
import { HttpClient } from '@angular/common/http'
import { Router } from '@angular/router'
import { NgForm } from '@angular/forms'
import { Identityserver_BaseDomain } from '../../../env';
import { RegisterVM } from '../../Models/Account/RegisterVM/register-vm.model';
import { LoginVM } from '../../Models/Account/LoginVM/login-vm.model';


@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {

  invalidLogin: boolean = true;
  //CurrentUser: UserModel;
  //isAutenticated: boolean = false;

  constructor(
    private http: HttpClient,
    private jwtHelperService: JwtHelperService,
    private router: Router) { }

  ErrorMessage: string;

  isAuhtenticated(): boolean {
    var token: string = "";
    token += localStorage.getItem("jwt");
    if (token && !this.jwtHelperService.isTokenExpired(token)) {
      return true;
    } else {
      return false;
    }
  }

  logOut() {
    console.log("try logout")
    this.http.get(Identityserver_BaseDomain + "Logout").subscribe(res => {
      console.log("Complete")
    }, err => {
      console.log(err);
    })
    //localStorage.removeItem("jwt");
    this.invalidLogin = true;
  }

  Register(RegisterVM: RegisterVM) {
    return this.http.post(Identityserver_BaseDomain + "api/Account/Register", RegisterVM).subscribe(
      response => {
        console.log("Done");
        this.ErrorMessage = '';

      },
      err => {
        this.invalidLogin = true;
        console.log(err.error);
        this.ErrorMessage = err.error;
      });
  }


  login(model: LoginVM) {
    this.http.post(Identityserver_BaseDomain + "api/Account/login", model).subscribe(
      response => {
        const token: string = (<any>response).token;

        console.log(token)
        localStorage.setItem("jwt", token);
        this.invalidLogin = false;
        this.router.navigate(["/"]);
        console.log("Done");
      },
      err => {
        this.invalidLogin = true;
        console.log(err);
      });
  }


  wt() {
    this.http.get("https://localhost:7006/api/_3dModel/1").subscribe(
      response => {
        console.log("response");
      },
      err => {
        console.log(err);
      });
  }

  //GetInfoAboutCurrentUser() {
  //  return this.http.get("http://localhost:46574/api/Auth/GetInfoAbutUser").subscribe(res => {
  //    console.log(res);
  //    console.log("==================")
  //    //console.log(res as UserModel);


  //    this.CurrentUser = res as UserModel;
  //    console.log(this.CurrentUser.userName);
  //  },
  //    err => {
  //      console.log(err)
  //    })
  //}
}
