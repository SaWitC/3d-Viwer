import { HttpClient, HttpEventType } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { empty, finalize, Subscription } from 'rxjs';
import { Model3D } from '../../../Models/3DModel/model3-d.model';
import { CategoryServiceService } from '../../../Services/Category/category-service.service';
import { ModelService } from '../../../Services/_3dModel/model.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  constructor(public CategoryS: CategoryServiceService, public Model3DS: ModelService, private http: HttpClient) { }

  ngOnInit(): void {
    this.CategoryS.GetCategories();
  }

  //private file: File;
  // fileName: string;

  //onFileSelected(event) {
  //  this.file = event.target.files[0];
  //  if (this.file) {
  //    this.fileName = this.file.name;
  //  }
  //}

  public Create(form: NgForm) {
    var model = new Model3D();
    model.title = form.value.title;
    model.description = form.value.description;
    model.category = form.value.category;
    model.avtorId = "1";
    console.log(model);

   // console.log(this.CategoryS.Categories)

    this.Model3DS.Create(model)
  }


}
