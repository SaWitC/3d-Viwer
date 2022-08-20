import { Component, OnInit } from '@angular/core';
import { ResourceServer_BaseDomain, ResourceServer__3dModelController } from '../../../../env';
import { ModelService } from '../../../Services/_3dModel/model.service';

@Component({
  selector: 'app-my-models',
  templateUrl: './my-models.component.html',
  styleUrls: ['./my-models.component.css']
})
export class MyModelsComponent implements OnInit {

  constructor(public ModelS: ModelService) { }
  public readonly apiPath: string = ResourceServer_BaseDomain + "api/" + ResourceServer__3dModelController +"/Upload/";

  ngOnInit(): void {
    this.ModelS.GetMyModels(0);
    
  }

}
