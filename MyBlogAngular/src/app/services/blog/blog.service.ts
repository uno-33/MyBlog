import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { ApiPaths } from 'src/apipaths';
import { Article } from 'src/app/_models/article';
import { Blog } from 'src/app/_models/blog';
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

  getById(id: number) {
    let url = `${this.baseUrl}${ApiPaths.Blogs}/${id}`;
    return this._http.get<Blog>(url);
  }

  getArticlesByBlogId(id: number) {
    let url = `${this.baseUrl}${ApiPaths.Blogs}/${id}/articles`;
    return this._http.get<Article[]>(url);
  }

  create(name: string, description: string) {
    let url = `${this.baseUrl}${ApiPaths.Blogs}`;
    return this._http.post<Blog>(url, {name, description});
  }

  edit(id: number, name: string, description: string) {
    let url = `${this.baseUrl}${ApiPaths.Blogs}/${id}`;
    return this._http.put<number>(url, {name, description});
  }

  delete(id: number) {
    let url = `${this.baseUrl}${ApiPaths.Blogs}/${id}`;
    return this._http.delete<boolean>(url);
  }
}
