import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Route, Router, RouterStateSnapshot, UrlTree } from '@angular/router'
import { Observable } from 'rxjs';
import { RequiredDataService } from '../../Services/RequiredData/required-data.service';

@Injectable({
  providedIn: 'root'
})
export class IsBrowserEnabledService implements CanActivate {

  constructor(private requireddatasevice: RequiredDataService,private router: Router) { }


  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    if (this.requireddatasevice.CheckIsBrowserEnabledWebgl2()) {
      return true;
    }
    this.router.navigate(["BrowserNotEnabledWebgl"])
    return false;
  }
  
}
