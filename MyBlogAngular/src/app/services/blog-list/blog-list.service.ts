import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { ApiPaths } from 'src/apipaths';
import { environment } from 'src/environments/environment';
import { Blog } from '../../_models/blog';

@Injectable({
  providedIn: 'root'
})
export class BlogListService {
  private baseUrl = environment.baseUrl;

  constructor(private _http: HttpClient) { }

  getBlogs() : Observable<Blog[]> {
    let url = `${this.baseUrl}${ApiPaths.Blogs}`;
    return this._http.get<Blog[]>(url);
  }
}
