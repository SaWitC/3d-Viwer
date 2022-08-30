import { HttpClient, HttpEventType } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { empty, finalize, Subscription } from 'rxjs';
import { Create3DModel } from '../../../Models/3DModel/Create3DModel/create3-dmodel.model';
import { Model3D } from '../../../Models/3DModel/model3-d.model';
import { CategoryServiceService } from '../../../Services/Category/category-service.service';
import { TagService } from '../../../Services/Tag/tag.service';
import { ModelService } from '../../../Services/_3dModel/model.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  constructor(public CategoryS: CategoryServiceService, public Model3DS: ModelService, private http: HttpClient, public TagS: TagService) { }

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
    var model = new Create3DModel();
    model.title = form.value.title;
    model.description = form.value.description;
    model.category = form.value.category;
    model.TagsString = form.value.tagstring;
    model.avtorId = "1";

   // console.log(this.CategoryS.Categories)

    this.Model3DS.Create(model)
  }

  public GetThins(event) {
    var len = event.target.value.length
    var indx1 = event.target.value.lastIndexOf(',');
    var indx2 = event.target.value.lastIndexOf('.');
    var indx3 = event.target.value.lastIndexOf('#');
    var indx4 = event.target.value.lastIndexOf('@');

    var index =Math.max(indx1, indx2, indx3, indx4)
    
    var value = event.target.value.substr(index + 1, len);
    //console.log(value);


    if (value.length>3) {
      this.TagS.getTaghints(value);
      //console.log(this.TagS.TagHints);
    }
    else {
      //console.log("-")
    }
  }

  public insertInto(event,id) {

    var element = document.getElementById(id) as HTMLInputElement;
    if (element != null) {
      var indx1 = element.value.lastIndexOf(',');
      var indx2 = element.value.lastIndexOf('.');
      var indx3 = element.value.lastIndexOf('#');
      var indx4 = element.value.lastIndexOf('@');

      var index = Math.max(indx1, indx2, indx3, indx4)

      console.log(index)
      var val = element.value = element.value.substring(0, index+1) + event.target.value;
    }

  }


}
