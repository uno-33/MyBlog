import { Component, OnInit } from '@angular/core';
import { ArticleService } from '../services/article/article.service';

@Component({
  selector: 'app-search-box',
  templateUrl: './search-box.component.html',
  styleUrls: ['./search-box.component.css']
})
export class SearchBoxComponent implements OnInit {

  constructor(private _articleService : ArticleService) { }

  ngOnInit(): void {
  }

}
