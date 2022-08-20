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
import { MyModelsComponent } from './Components/3dModel/my-models/my-models.component';
import { ViwerComponent } from './Components/3dModel/viwer/viwer.component';

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
    FileUploadComponent,
    MyModelsComponent,
    ViwerComponent
  ],
  imports: [
    //MatIconModule,
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
    })
  ],
  providers: [AuthServiceService, CategoryServiceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
