import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-tag-add-dialog',
  templateUrl: './tag-add-dialog.component.html',
  styleUrls: ['./tag-add-dialog.component.css']
})
export class TagAddDialogComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<TagAddDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public dialogData: {tagName: string}) { }

  ngOnInit(): void {
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
