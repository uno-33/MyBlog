import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Blog } from '../models/blog';
import { switchMap } from 'rxjs/internal/operators/switchMap';
import { BlogService } from '../services/blog/blog.service';
import { Article } from '../models/article';

@Component({
  selector: 'app-blog-page',
  templateUrl: './blog-page.component.html',
  styleUrls: ['./blog-page.component.css']
})
export class BlogPageComponent implements OnInit {

  id: number = 0;
  blog!: Blog;
  articles : Article[] = [];
  
  constructor(private _activateRoute : ActivatedRoute, private _blogService : BlogService) { }

  ngOnInit(): void {
    this._activateRoute.paramMap.pipe(
      switchMap(params => params.getAll('id'))
    )
    .subscribe(data => this.id = +data);
    
    this._blogService.getById(this.id)
      .subscribe(blog => this.blog = blog);

    this._blogService.getArticlesByBlogId(this.id)
      .subscribe(articles => this.articles = articles);
  }

}
