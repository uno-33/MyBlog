import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { switchMap } from 'rxjs';
import { Article } from '../models/article';
import { ArticleService } from '../services/article/article.service';

@Component({
  selector: 'app-article-page',
  templateUrl: './article-page.component.html'
})
export class ArticlePageComponent implements OnInit {

  blogId: number = 0;
  articleId: number = 0;
  article! : Article;
  
  constructor(private _activateRoute : ActivatedRoute, private _articleService : ArticleService) { }

  ngOnInit(): void {
    this._activateRoute.paramMap.pipe(
      switchMap(params => params.getAll('id'))
    )
    .subscribe(data => this.blogId = +data);

    this._activateRoute.paramMap.pipe(
      switchMap(params => params.getAll('articleid'))
    )
    .subscribe(data => this.articleId = +data);
    
    this._articleService.getById(this.articleId)
      .subscribe(article => this.article = article);
  }

}
