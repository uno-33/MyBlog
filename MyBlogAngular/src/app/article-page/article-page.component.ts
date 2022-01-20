import { formatDate } from '@angular/common';
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
  formattedDate: string = '';
  
  constructor(private _activateRoute : ActivatedRoute, private _articleService : ArticleService) { }

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
        this.article = article
        this.formattedDate = formatDate(this.article.creationDate, 'dd/MM/yyyy', 'en-US');
      });
  }

}
