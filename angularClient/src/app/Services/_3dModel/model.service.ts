import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ResourceServer_BaseDomain, ResourceServer__3dModelController } from '../../../env';
import { Model3D } from '../../Models/3DModel/model3-d.model';

@Injectable({
  providedIn: 'root'
})
export class ModelService {

  constructor(private http: HttpClient) { }

  public Create(model: Model3D) {
    this.http.post(ResourceServer_BaseDomain + "api/" + ResourceServer__3dModelController, model).subscribe(res => {
      console.log(res);
    },
      err => {
        console.log(err);
      }    )
  }

  public Update() {

  }

  public Delete() {

  }

  public GetById() {

  }


}
