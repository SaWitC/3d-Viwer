import { Component, OnInit } from '@angular/core';
import { ModelService } from '../../../Services/_3dModel/model.service';

@Component({
  selector: 'app-my-models',
  templateUrl: './my-models.component.html',
  styleUrls: ['./my-models.component.css']
})
export class MyModelsComponent implements OnInit {

  constructor(public ModelS: ModelService) { }

  ngOnInit(): void {
    this.ModelS.GetMyModels(0);
  }

}
