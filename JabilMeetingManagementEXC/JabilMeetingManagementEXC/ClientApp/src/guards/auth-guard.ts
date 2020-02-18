import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private router : Router){}
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean {
    let userToken = localStorage.getItem('jwtToken');
    if (userToken != null && userToken != undefined && userToken.length != 0)
      return true;
    else {
      this.router.navigate(['login']);
      return false;
    }
  }
}
