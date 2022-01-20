import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth/auth.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private _authService: AuthService) {}


  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    const user = this._authService.userValue;
      const isLoggedIn = user && user.token;

    if (isLoggedIn) {
      req = req.clone({
        setHeaders: {
          Authorization: `Bearer ${user.token}`
        }
      });
    }

    return next.handle(req);

    /*const Token = localStorage.getItem("token");

    if (Token) {
      const cloned = req.clone({
          headers: req.headers.set("Authorization",
              "Bearer " + Token)
        });

      return next.handle(cloned);
    }
    else {
      return next.handle(req);
    }*/
  }
}
