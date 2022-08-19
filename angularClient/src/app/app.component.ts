import { Component, OnInit } from '@angular/core';
import {AuthServiceService } from './Services/Auth/auth-service.service'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: [
    './app.component.css',
    '../../node_modules/bootstrap/dist/css/bootstrap.min.css'
  ]
})
export class AppComponent implements OnInit {

  constructor(public auth: AuthServiceService) { }

  ngOnInit(): void {
    //this.invalidLogin = this.auth.invalidLogin;
  }


  public logout() {
    
    this.auth.logOut();
  }
  title = 'angularClient';
}
