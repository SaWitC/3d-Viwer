import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MyModelsComponent } from './my-models.component';

const routes: Routes = [{ path: '', component: MyModelsComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MyModelsRoutingModule { }
