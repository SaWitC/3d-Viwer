import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RequiredDataService {

  public IsBrowserEnabledWebgl2: boolean;

  CheckIsBrowserEnabledWebgl2(): boolean {
    const gl = document.createElement('canvas').getContext('webgl2');
    if (!gl) {
      this.IsBrowserEnabledWebgl2 = false;
      return false;
    } else {
      this.IsBrowserEnabledWebgl2 = true;
      return true;
    }
  }

  constructor() { }
}
