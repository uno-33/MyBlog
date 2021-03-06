import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { switchMap } from 'rxjs';
import { ArticleService } from '../services/article/article.service';

@Component({
  selector: 'app-article-delete-page',
  templateUrl: './article-delete-page.component.html',
  styleUrls: ['./article-delete-page.component.css']
})
export class ArticleDeletePageComponent implements OnInit {

  deleteArticleForm:FormGroup;
  articleId: number = 0;
  blogId: number = 0;
  
  constructor(
    private fb:FormBuilder, 
    private _articleService : ArticleService, 
    private _router: Router, 
    private _activatedRoute: ActivatedRoute) { 

    this.deleteArticleForm = fb.group({
      title: [{ value: '', disabled: true }, Validators.required],
      content: [{ value: '', disabled: true }, Validators.required]
    });
  }

  ngOnInit(): void {

    this._activatedRoute.paramMap.pipe(
      switchMap(params => params.getAll('id'))
    )
    .subscribe(data => this.blogId = +data);

    this._activatedRoute.paramMap.pipe(
      switchMap(params => params.getAll('articleid'))
    )
    .subscribe(data => this.articleId = +data);
    
    this._articleService.getById(this.articleId)
      .subscribe(article => {
        this.deleteArticleForm.setValue({
          title: article.title,
          content: article.content
        });
      });
  }

  onSubmit() {

    this._articleService.delete(this.articleId)
    .subscribe(() => {
      this._router.navigate(['blogs', this.blogId]);
    })
  }

}