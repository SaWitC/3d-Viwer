import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ResourceServer_BaseDomain, ResourceServer_TagController } from '../../../env';
import { Tag } from '../../Models/Tag/tag.model';

@Injectable({
  providedIn: 'root'
})
export class TagService {

  constructor(private http: HttpClient) { }

  public TagHints: Tag[];

  public getTaghints(substr: string) {
    this.http.get(ResourceServer_BaseDomain + "api/" + ResourceServer_TagController + "/" + substr)
      .subscribe(
        res => {
          this.TagHints = res as Tag[];
        },
      err => {
        console.log(err);
      });
  }
}
