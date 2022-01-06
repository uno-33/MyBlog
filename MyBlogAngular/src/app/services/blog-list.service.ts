import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Blog } from '../models/blog';

@Injectable({
  providedIn: 'root'
})
export class BlogListService {
  private blogsLink = 'https://localhost:4200/api/Blogs';

  constructor(private _http: HttpClient) { }

  getBlogs() : Observable<Blog[]> {
    return this._http.get<Blog[]>(this.blogsLink);
  }
}
