import { HttpInterceptor, HttpHandler, HttpRequest, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/do';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private router: Router) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (req.headers.get('No-Auth') == 'True')
      return next.handle(req.clone());
    let currentUserToken = (localStorage.getItem('jwtToken'));
    if (currentUserToken && currentUserToken.length > 100) {
      req = req.clone({
        setHeaders: { "Authorization": `Bearer ${currentUserToken}` }
      });
      return next.handle(req)
        .do(
          succ => { },
          err => {
            if (err.status == 401) {
              this.router.navigate(['login']);
            }
          }
        );
    }
    else {
      this.router.navigate(['login']);
    }


  }
}
