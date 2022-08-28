import { Component, OnInit } from '@angular/core';
import { HomeService } from '../../Services/Home/home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(public homeS: HomeService) { }

  ngOnInit(): void {
    this.homeS.getRes();
    
  }

}
