import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiPaths } from 'src/apipaths';
import { Article } from 'src/app/models/article';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {
  private baseUrl = environment.baseUrl;

  constructor(private _http: HttpClient) { }

  getLatest(count = 5) {
    let url = `${this.baseUrl}${ApiPaths.Articles}/latest/${count}`;

    return this._http.get<Article[]>(url);
  }

  getByText(text: string) {
    let url = `${this.baseUrl}${ApiPaths.Articles}/search?text=${text}`;

    return this._http.get<Article[]>(url);
  }
}
