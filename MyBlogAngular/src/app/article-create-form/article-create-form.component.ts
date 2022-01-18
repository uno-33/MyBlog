import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { switchMap } from 'rxjs';
import { ApiPaths } from 'src/apipaths';
import { ArticleService } from '../services/article/article.service';

@Component({
  selector: 'app-article-create-form',
  templateUrl: './article-create-form.component.html',
  styleUrls: ['./article-create-form.component.css']
})
export class ArticleCreateFormComponent implements OnInit {

  blogId: number = 0;
  createArticleForm:FormGroup;
  
  constructor(private fb:FormBuilder, 
    private _articleService : ArticleService, 
    private _router: Router, 
    private _activatedRoute: ActivatedRoute) { 

    this.createArticleForm = fb.group({
      title: ['', Validators.required],
      content: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this._activatedRoute.paramMap.pipe(
      switchMap(params => params.getAll('id'))
    )
    .subscribe(data => this.blogId = +data);
  }

  onSubmit() {
    const val = this.createArticleForm.value;

    if(val.title && val.content) {
      this._articleService.create(val.title, val.content, this.blogId)
      .subscribe(article => {
        this._router.navigate(['blogs', this.blogId, 'articles', article.id]);
      })
    }
  }

}
