import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ResourceServer_BaseDomain, ResourceServer_homeController } from '../../../env';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  public ResourceLinks: string[];

  constructor(private http: HttpClient) { }

  public getRes() {
    this.http.get(ResourceServer_BaseDomain + "api/" + ResourceServer_homeController).subscribe(res => {
      this.ResourceLinks = res as string[];
    },
      err => {
        console.log(err);
      })
  }
}
