import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiPaths } from 'src/apipaths';
import { LoginResult } from 'src/app/models/loginresult';
import { environment } from 'src/environments/environment';
import * as moment from "moment";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = environment.baseUrl;   

  constructor(private _http: HttpClient) {
  }
    
  login(username:string, password:string ) {
    let url = `${this.baseUrl}${ApiPaths.Accounts}/login`;
    let res = this._http.post<LoginResult>(url, {username, password});

    res.subscribe(authRes => this.setSession(authRes));
    return res;
  }

  private setSession(authResult : LoginResult) {
    const expiresAt = moment().add(authResult.expiresIn,'minutes');

    localStorage.setItem('token', authResult.token);
    localStorage.setItem("expires_at", JSON.stringify(expiresAt.valueOf()) );
  }          

  logout() {
      localStorage.removeItem("token");
      localStorage.removeItem("expires_at");
  }

  public isLoggedIn() {
      return moment().isBefore(this.getExpiration());
  }

  isLoggedOut() {
      return !this.isLoggedIn();
  }

  getExpiration() {
      let expiration = localStorage.getItem("expires_at");
      //let expiresAt = JSON.parse(expiration);

      return moment(expiration);
  }
}
