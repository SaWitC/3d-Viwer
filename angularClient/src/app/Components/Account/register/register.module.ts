import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RegisterRoutingModule } from './register-routing.module';
import { RegisterComponent } from './register.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { tokenGetter } from '../../../app.module';
import { JwtModule } from '@auth0/angular-jwt';


@NgModule({
  declarations: [
    RegisterComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RegisterRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    //JwtModule.forRoot({
    //  config: {
    //    tokenGetter: tokenGetter,
    //    allowedDomains: ["localhost:7074", "localhost:7006"],
    //    disallowedRoutes: []
    //  }
    //}),
  ]
})
export class RegisterModule { }
