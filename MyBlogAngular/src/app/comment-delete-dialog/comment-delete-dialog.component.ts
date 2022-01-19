import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-comment-delete-dialog',
  templateUrl: './comment-delete-dialog.component.html',
  styleUrls: ['./comment-delete-dialog.component.css']
})
export class CommentDeleteDialogComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<CommentDeleteDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public commentData: {content: string}) { }

  ngOnInit(): void {

  }

  onNoClick(): void {
    this.dialogRef.close();
  }

}
