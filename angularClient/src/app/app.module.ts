import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CreateComponent } from './Components/3dModel/create/create.component';
import { DetailsComponent } from './Components/3dModel/details/details.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AccountLoginComponentComponent } from './Components/Account/account-login-component/account-login-component.component';
import { AuthServiceService } from './Services/Auth/auth-service.service';
import { HttpClientModule } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';
import { RegisterComponent } from './Components/Account/register/register.component';
import { CategoryServiceService } from './Services/Category/category-service.service';
import { FileUploadComponent } from './Components/File/file-upload/file-upload.component';
//import { MyModelsComponent } from './Components/3dModel/my-models/my-models.component';
import { ViwerComponent } from './Components/threeJS/viwer/viwer.component';
import { BrowsernotEnabled3dComponent } from './Components/Errors/browsernot-enabled3d/browsernot-enabled3d.component'
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FindComponent } from './Components/3dModel/find/find.component';
import { HomeComponent } from './Components/home/home.component';
import { HomeService } from './Services/Home/home.service';
//import { MyModelsModule } from './Components/3dModel/my-models/my-models.module';
//import { RegisterModule } from './Components/Account/register/register.module';

export function tokenGetter() {
  return localStorage.getItem("jwt");
}

@NgModule({
  declarations: [
    AppComponent,
    CreateComponent,
    DetailsComponent,
    AccountLoginComponentComponent,
    RegisterComponent,
    //FileUploadComponent,
    //MyModelsComponent,
    ViwerComponent,
    BrowsernotEnabled3dComponent,
    FindComponent,
    HomeComponent
  ],
  imports: [
    //MatIconModule,

    CommonModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:7074", "localhost:7006"],
        disallowedRoutes:[]
      }
    }),
    //MyModelsModule,
    //RegisterModule
  ],
  exports: [JwtModule, BrowserModule, HttpClientModule, AppRoutingModule],
  providers: [AuthServiceService, CategoryServiceService, HomeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
