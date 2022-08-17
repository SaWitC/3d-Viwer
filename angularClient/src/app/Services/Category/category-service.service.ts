import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ResourceServer_BaseDomain, ResourceServer_CategoryController } from '../../../env';
import { Category } from '../../Models/Category/category.model'

@Injectable({
  providedIn: 'root'
})
export class CategoryServiceService {

  public Categories: Category[]

  constructor(private http: HttpClient) { }

  public GetCategories() {
    this.http.get(ResourceServer_BaseDomain + "api/" + ResourceServer_CategoryController).subscribe(res => {
      this.Categories = res as Category[];
      console.log(this.Categories);
    },
      err => {
        console.log(err);
      });
  }
}
