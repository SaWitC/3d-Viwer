import { Injectable } from '@angular/core';
import { JwtHelperService } from "@auth0/angular-jwt"
import { HttpClient } from '@angular/common/http'
import { Router } from '@angular/router'
import { NgForm } from '@angular/forms'

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
    localStorage.removeItem("jwt");
    this.invalidLogin = true;
  }

  Register(form: NgForm) {
    const creadentialsreg = {
      Email: form.value.Email,
      userName: form.value.UserName,
      password: form.value.Password
    }
    console.log(creadentialsreg)

    return this.http.post("http://localhost:46574/api/Auth/api/Auth/Register", creadentialsreg).subscribe(
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


  login(form: NgForm) {
    const credentails = {
      userName: form.value.UserName,
      password: form.value.Password
    }

    console.log(credentails);
    this.http.post("https://localhost:7074/api/Account/api/Account/login", credentails).subscribe(
      response => {
        const token: string = (<any>response).token;
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
