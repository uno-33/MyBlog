import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiPaths } from 'src/apipaths';
import { LoginResult } from 'src/app/_models/loginresult';
import { environment } from 'src/environments/environment';
import * as moment from "moment";
import { AuthModel } from 'src/app/_models/auth';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { Observable } from 'rxjs/internal/Observable';
import { Router } from '@angular/router';
import { map } from 'rxjs/internal/operators/map';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseUrl = environment.baseUrl;
  private userSubject: BehaviorSubject<AuthModel>;
  public user: Observable<AuthModel>;

  constructor(private _http: HttpClient, private _router: Router) {

    this.userSubject = new BehaviorSubject<AuthModel>(JSON.parse(localStorage.getItem('user')!));
    this.user = this.userSubject.asObservable();
  }
  
  register(username:string, password:string) {
    let url = `${this.baseUrl}${ApiPaths.Auth}/register`;

    return this._http.post<boolean>(url, {username, password});
  }

  login(username:string, password:string ) {
    let url = `${this.baseUrl}${ApiPaths.Auth}/login`;

    return this._http.post<AuthModel>(url, { username, password })
            .pipe(map(user => {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                localStorage.setItem('user', JSON.stringify(user));
                this.userSubject.next(user);
                return user;
            }));
  }         

  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('user');
    this.userSubject.next(null!);
    this._router.navigate(['/login']);
  }

  public get userValue(): AuthModel {
    return this.userSubject.value;
  }

  public isOwner(userId: string) {
    if(this.userValue?.id == userId)
      return true;

    return false;
  }

  public isAdmin() {
    if(this.userValue?.roles.includes('Admin'))
      return true;

    return false;
  }

  public isLoggedIn() {
    if(this.userValue)
      return true;

    return false;
  }
}
