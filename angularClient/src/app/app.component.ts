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
    const gl = document.createElement('canvas').getContext('webgl2');
    if (!gl) {
      console.log('your browser/OS/drivers do not support WebGL2');
    } else {
      console.log('webgl2 works!');
    }
  }


  public logout() {
    
    this.auth.logOut();
  }
  title = 'angularClient';
}
