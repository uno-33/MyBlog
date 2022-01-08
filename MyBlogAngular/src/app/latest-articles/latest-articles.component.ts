import { Component, OnInit } from '@angular/core';
import { Article } from '../models/article';
import { ArticleService } from '../services/article/article.service';

@Component({
  selector: 'app-latest-articles',
  templateUrl: './latest-articles.component.html',
  styleUrls: ['./latest-articles.component.css']
})
export class LatestArticlesComponent implements OnInit {

  articles: Article[] = [];
  constructor(private _articleService : ArticleService) { }

  ngOnInit(): void {
    this._articleService.getLatest().subscribe(articles => this.articles = articles);
  }

}
