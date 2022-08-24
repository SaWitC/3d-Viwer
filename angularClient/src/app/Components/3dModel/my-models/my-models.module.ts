import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MyModelsRoutingModule } from './my-models-routing.module';
import { FormsModule, NgForm, ReactiveFormsModule } from '@angular/forms';
import { MyModelsComponent } from './my-models.component';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [
    MyModelsComponent
  ],
  imports: [
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    CommonModule,

    MyModelsRoutingModule,
    //ModelService
  ]
})
export class MyModelsModule { }
