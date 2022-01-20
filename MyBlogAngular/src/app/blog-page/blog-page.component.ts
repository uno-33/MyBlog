import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Blog } from '../_models/blog';
import { switchMap } from 'rxjs/internal/operators/switchMap';
import { BlogService } from '../services/blog/blog.service';
import { Article } from '../_models/article';
import { AuthService } from '../services/auth/auth.service';

@Component({
  selector: 'app-blog-page',
  templateUrl: './blog-page.component.html',
  styleUrls: ['./blog-page.component.css']
})
export class BlogPageComponent implements OnInit {

  id: number = 0;
  blog!: Blog;
  articles : Article[] = [];
  
  constructor(private _activateRoute : ActivatedRoute, 
    private _blogService : BlogService, 
    public _authService: AuthService) { }

  ngOnInit(): void {
    this._activateRoute.paramMap.subscribe(params => {
      this.id = Number(params.get('id'));

      this.LoadData();
    }) 
  }

  LoadData() {
    this._blogService.getById(this.id)
      .subscribe(blog => this.blog = blog);

    this._blogService.getArticlesByBlogId(this.id)
      .subscribe(articles => this.articles = articles);
  }

  public isAccessible() {
    if(this._authService.isOwner(this.blog?.creatorId!) || this._authService.isAdmin())
      return true;

    return false;
  }

}
