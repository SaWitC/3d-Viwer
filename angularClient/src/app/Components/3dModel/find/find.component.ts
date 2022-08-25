import { Component, OnInit } from '@angular/core';
import { ModelService } from '../../../Services/_3dModel/model.service';

@Component({
  selector: 'app-find',
  templateUrl: './find.component.html',
  styleUrls: ['./find.component.css']
})
export class FindComponent implements OnInit {

  constructor(public ModelS: ModelService) { }

  ngOnInit(): void {
    this.ModelS.GetPage(0, "", "");
  }

}
