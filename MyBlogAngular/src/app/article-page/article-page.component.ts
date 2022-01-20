import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { switchMap } from 'rxjs';
import { Article } from '../_models/article';
import { ArticleService } from '../services/article/article.service';
import { AuthService } from '../services/auth/auth.service';

@Component({
  selector: 'app-article-page',
  templateUrl: './article-page.component.html'
})
export class ArticlePageComponent implements OnInit {

  blogId: number = 0;
  articleId: number = 0;
  article! : Article;
  
  constructor(private _activateRoute : ActivatedRoute, 
    private _articleService : ArticleService,
    public _authService: AuthService) { }

  ngOnInit(): void {

    this._activateRoute.paramMap.subscribe(params => {
      this.blogId = Number(params.get('id'));
      this.articleId = Number(params.get('articleid'));

      this.LoadData();
    })    
  }

  LoadData() {
    this._articleService.getById(this.articleId)
      .subscribe(article => {
        this.article = article;
      });
  }

  public isAccessible() {
    if(this._authService.isOwner(this.article?.creatorId!) || this._authService.isAdmin())
      return true;

    return false;
  }

}
