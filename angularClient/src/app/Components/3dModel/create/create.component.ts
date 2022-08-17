import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CategoryServiceService } from '../../../Services/Category/category-service.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  constructor(public CategoryS: CategoryServiceService) { }

  ngOnInit(): void {
    this.CategoryS.GetCategories();
  }

  public Create(form: NgForm) {
    
  }
}
