import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiPaths } from 'src/apipaths';
import { Article } from 'src/app/models/article';
import { Tag } from 'src/app/models/tag';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TagService {

  private baseUrl = environment.baseUrl;

  constructor(private _http: HttpClient) { }

  getByArticleId(id: number) {
    let url = `${this.baseUrl}${ApiPaths.Articles}/${id}/tags`;
    return this._http.get<Tag[]>(url);
  }

  getArticlesByTag(tagName: string) {
    let url = `${this.baseUrl}${ApiPaths.Articles}/tag?tagName=${tagName}`;
    return this._http.get<Article[]>(url);
  }

  removeTag(articleId: number, tagName: string) {
    let url = `${this.baseUrl}${ApiPaths.Articles}/${articleId}${ApiPaths.Tags}/${tagName}`;
    return this._http.delete(url);
  }

  addTag(articleId: number, name: string) {
    let url = `${this.baseUrl}${ApiPaths.Articles}/${articleId}${ApiPaths.Tags}`;
    return this._http.post(url, {name});
  }
}
