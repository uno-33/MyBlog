import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { switchMap } from 'rxjs';
import { CommentService } from '../services/comment/comment.service';
import { Comment } from '../models/comment';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-comment-list',
  templateUrl: './comment-list.component.html',
  styleUrls: ['./comment-list.component.css']
})
export class CommentListComponent implements OnInit {

  articleId: number = 0;
  comments: Comment[] = [];
  addCommentForm:FormGroup;

  constructor(private _activateRoute: ActivatedRoute, private _commentService: CommentService, private fb:FormBuilder) {
    this.addCommentForm = fb.group({
      content: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this._activateRoute.paramMap.pipe(
      switchMap(params => params.getAll('articleid'))
    )
    .subscribe(data => this.articleId = +data);

    this._commentService.getAll(this.articleId)
      .subscribe(comments => this.comments = comments);
  }

  addComment() {
    const val = this.addCommentForm.value;

    if(val.content) {
      this._commentService.create(this.articleId, val.content)
      .subscribe(() => {
        this.ngOnInit();
      })
    }
  }

}
