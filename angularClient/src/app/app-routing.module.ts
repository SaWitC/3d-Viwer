import { Component, NgModule } from '@angular/core';
import { Router, RouterModule, Routes } from '@angular/router';

import { AccountLoginComponentComponent } from './Components/Account/account-login-component/account-login-component.component';
import { CreateComponent } from './Components/3dModel/create/create.component'
import { RegisterComponent } from './Components/Account/register/register.component'
import { MyModelsComponent } from './Components/3dModel/my-models/my-models.component'
import { BrowsernotEnabled3dComponent } from './Components/Errors/browsernot-enabled3d/browsernot-enabled3d.component'

import { AuthGuardService } from './Guards/Auth/auth-guard.service'
import { IsBrowserEnabledService } from './Guards/IsBrowserenabledRequiredComponents/is-browser-enabled.service'


const routes: Routes = [
  { path: "Create3dModel", component: CreateComponent, canActivate: [AuthGuardService, IsBrowserEnabledService] },
  { path: "AccountLogin", component: AccountLoginComponentComponent, canActivate: [IsBrowserEnabledService] },
  { path: "Register", component: RegisterComponent, canActivate: [IsBrowserEnabledService] },
  { path: "MyModels", component: MyModelsComponent, canActivate: [AuthGuardService, IsBrowserEnabledService] },
  { path: "BrowserNotEnabledWebgl" ,component: BrowsernotEnabled3dComponent }
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
