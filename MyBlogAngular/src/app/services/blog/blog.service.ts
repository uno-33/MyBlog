import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { ApiPaths } from 'src/apipaths';
import { Blog } from 'src/app/models/blog';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BlogService {

  private baseUrl = environment.baseUrl;

  constructor(private _http : HttpClient) { }
  
  getLatest(count = 5) : Observable<Blog[]> {
    let url = `${this.baseUrl}${ApiPaths.Blogs}/latest/${count}`;
    return this._http.get<Blog[]>(url);
  }
}
