import { Component, NgModule } from '@angular/core';
import { Router, RouterModule, Routes } from '@angular/router';
import { AccountLoginComponentComponent } from './Components/Account/account-login-component/account-login-component.component';

import { CreateComponent } from './Components/3dModel/create/create.component'
import { RegisterComponent } from './Components/Account/register/register.component'

const routes: Routes = [
  { path: "Create3dModel", component: CreateComponent },
  { path: "AccountLogin", component: AccountLoginComponentComponent },
  { path: "Register", component: RegisterComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
