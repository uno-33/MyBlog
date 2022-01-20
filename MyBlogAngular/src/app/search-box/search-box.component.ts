import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ArticleService } from '../services/article/article.service';

@Component({
  selector: 'app-search-box',
  templateUrl: './search-box.component.html',
  styleUrls: ['./search-box.component.css']
})
export class SearchBoxComponent implements OnInit {

  searchBoxForm:FormGroup;

  constructor(fb: FormBuilder, private _router: Router) { 
    this.searchBoxForm = fb.group({
      searchText: ['', Validators.required]
    });
  }

  ngOnInit(): void {
  }

  searchArticlesByText() {
    const val = this.searchBoxForm.value;

    if(val.searchText) {

      this._router.navigate(
        ['/search'], 
        {
            queryParams:{
                'text': val.searchText
            }
        }
      );
    }
  }

}
