import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ResourceServer_BaseDomain, ResourceServer__3dModelController } from '../../../env';
import { DetailsModel3D } from '../../Models/3DModel/Details3DModel/details-model3-d.model';
import { Model3D } from '../../Models/3DModel/model3-d.model';
import { Short3dModel } from '../../Models/3DModel/Short3dModel/short3d-model.model';

@Injectable({
  providedIn: 'root'
})
export class ModelService {

  //data
  public MyModels: Model3D[];
  public ViewModels: Short3dModel[];

  public CurentModel: DetailsModel3D;


  constructor(private http: HttpClient) { }

  public GetPage(page: number, SerachString: string, CategoryId: string) {
    this.http.get(ResourceServer_BaseDomain + "api/" + ResourceServer__3dModelController + "/Get/" + page)
      .subscribe(res => { this.ViewModels = res as Short3dModel[] },
      err => console.log(err)
      );
  }

  public Create(model: Model3D) {
    this.http.post(ResourceServer_BaseDomain + "api/" + ResourceServer__3dModelController, model).subscribe(res => {
      console.log(res);
    },
      err => {
        console.log(err);
      }    )
  }

  public GetMyModels(page: number) {

    this.http.get(ResourceServer_BaseDomain + "api/" + ResourceServer__3dModelController + "/GetMyModels/" + page).subscribe(res => {
      this.MyModels = res as Model3D[];
    },
    err => {
        console.log(err)
    });
  }

  public GetModelById(id: string) {
    this.http.get(ResourceServer_BaseDomain + "api/" + ResourceServer__3dModelController + "Details/" + id).
      subscribe(res => { this.CurentModel = res as DetailsModel3D },
        err => console.log(err)
    )
  }

  public Update() {

  }

  public Delete(id:string) {
    this.http.get(ResourceServer_BaseDomain + "api/" + ResourceServer__3dModelController + "/" + id)
      .subscribe(res => { console.log(res) },
        err => { console.log(err) }
      )
  }

}
