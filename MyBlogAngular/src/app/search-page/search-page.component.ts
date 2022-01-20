import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { map, Subscription } from 'rxjs';
import { Article } from '../_models/article';
import { ArticleService } from '../services/article/article.service';

@Component({
  selector: 'app-search-page',
  templateUrl: './search-page.component.html',
  styleUrls: ['./search-page.component.css']
})
export class SearchPageComponent implements OnInit {

  searchText: string | null = '';
  searchTag : string | null = '';
  articles: Article[] = [];
  message: string = '';

  constructor(private _route: ActivatedRoute, private _articleService: ArticleService) {
  }

  ngOnInit(): void {
    

    this._route.queryParamMap.subscribe( queryParams => { 
      this.searchText = queryParams.get("text");
      this.searchTag = queryParams.get("tag");

      this.LoadData();
    })
  }

  LoadData() {
    if(this.searchText != null) {
      this._articleService.getByText(this.searchText)
        .subscribe(articles => this.articles = articles);
      this.message = 'Search by text: ' + this.searchText;
    }
    else if(this.searchTag != null) {
      this._articleService.getByTag(this.searchTag)
        .subscribe(articles => this.articles = articles);
      this.message = 'Search by tag: ' + this.searchTag;
    }
  }
}
