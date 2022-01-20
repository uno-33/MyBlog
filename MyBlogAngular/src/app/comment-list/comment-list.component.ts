import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { switchMap } from 'rxjs';
import { CommentService } from '../services/comment/comment.service';
import { Comment } from '../models/comment';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { CommentEditDialogComponent } from '../comment-edit-dialog/comment-edit-dialog.component';
import { CommentDeleteDialogComponent } from '../comment-delete-dialog/comment-delete-dialog.component';

@Component({
  selector: 'app-comment-list',
  templateUrl: './comment-list.component.html',
  styleUrls: ['./comment-list.component.css']
})
export class CommentListComponent implements OnInit {

  articleId: number = 0;
  comments: Comment[] = [];
  addCommentForm:FormGroup;

  constructor(private _activateRoute: ActivatedRoute, 
    private _commentService: CommentService, 
    private fb:FormBuilder,
    public dialog: MatDialog) {

    this.addCommentForm = fb.group({
      content: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    
    this._activateRoute.paramMap.subscribe(params => {
      this.articleId = Number(params.get('articleid'));

      this.LoadData();
    })  
  }

  LoadData() {
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

  openEditCommentDialog(comment: Comment) {
    const dialogRef = this.dialog.open(CommentEditDialogComponent, {
      data: {content: comment.content, id: comment.id},
    });

    dialogRef.afterClosed().subscribe(content => {
      this._commentService.update(comment.id, content)
        .subscribe(() => this.ngOnInit());
    });
  }

  openDeleteCommentDialog(comment: Comment) {
    const dialogRef = this.dialog.open(CommentDeleteDialogComponent, {
      data: {content: comment.content},
    });

    dialogRef.afterClosed().subscribe(res => {
      if(res) {
        this._commentService.delete(comment.id)
        .subscribe(() => this.ngOnInit());
      }
    });
  }

}
