import { Component, OnInit } from '@angular/core';
import { ModelService } from '../../../Services/_3dModel/model.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {

  constructor(public modelS: ModelService) { }

  ngOnInit(): void {
    
  }

}
