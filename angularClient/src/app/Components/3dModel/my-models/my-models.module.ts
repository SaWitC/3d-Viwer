import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MyModelsRoutingModule } from './my-models-routing.module';
import { FormsModule, NgForm, ReactiveFormsModule } from '@angular/forms';
import { MyModelsComponent } from './my-models.component';
import { HttpClientModule } from '@angular/common/http';
import { FileUploadComponent } from '../../File/file-upload/file-upload.component';


@NgModule({
  declarations: [
    MyModelsComponent,
    FileUploadComponent
  ],
  imports: [
    FormsModule,
    CommonModule,

    MyModelsRoutingModule,
    //ModelService
  ]
})
export class MyModelsModule { }
