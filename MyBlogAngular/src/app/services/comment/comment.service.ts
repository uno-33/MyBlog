import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiPaths } from 'src/apipaths';
import { environment } from 'src/environments/environment';
import { Comment } from 'src/app/models/comment';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  private baseUrl = environment.baseUrl;

  constructor(private _http: HttpClient) { }

  getAll(articleId: number) {
    let url = `${this.baseUrl}${ApiPaths.Articles}/${articleId}/comments`;
    return this._http.get<Comment[]>(url);
  }

  create(articleId: number, content: string) {
    let url = `${this.baseUrl}${ApiPaths.Comments}`;
    return this._http.post<Comment>(url, {content, articleId});
  }

  update(commentId: number, content: string) {
    let url = `${this.baseUrl}${ApiPaths.Comments}/${commentId}`;
    return this._http.put(url, {content});
  }

  delete(commentId: number) {
    let url = `${this.baseUrl}${ApiPaths.Comments}/${commentId}`;
    return this._http.delete(url);
  }
}



