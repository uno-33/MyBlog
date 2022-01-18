import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { switchMap } from 'rxjs';
import { ApiPaths } from 'src/apipaths';
import { ArticleService } from '../services/article/article.service';

@Component({
  selector: 'app-article-edit-form',
  templateUrl: './article-edit-form.component.html',
  styleUrls: ['./article-edit-form.component.css']
})
export class ArticleEditFormComponent implements OnInit {

  editArticleForm:FormGroup;
  articleId: number = 0;
  blogId: number = 0;
  
  constructor(
    private fb:FormBuilder, 
    private _articleService : ArticleService, 
    private _router: Router, 
    private _activatedRoute: ActivatedRoute) { 

    this.editArticleForm = fb.group({
      title: ['', Validators.required],
      content: ['', Validators.required]
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
        this.editArticleForm.setValue({
          title: article.title,
          content: article.content
        });
      });
  }

  onSubmit() {
    const val = this.editArticleForm.value;

    if(val.title && val.content) {
      this._articleService.edit(this.articleId, val.title, val.content)
      .subscribe(article => {
        this._router.navigate(['blogs', this.blogId, 'articles', article.id]);
      })
    }
  }

}
