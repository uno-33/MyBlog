import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { switchMap } from 'rxjs';
import { Tag } from '../models/tag';
import { TagAddDialogComponent } from '../tag-add-dialog/tag-add-dialog.component';
import { TagService } from '../services/tag/tag.service';

@Component({
  selector: 'app-tag-list',
  templateUrl: './tag-list.component.html',
  styleUrls: ['./tag-list.component.css']
})
export class TagListComponent implements OnInit {

  articleId = 0;
  tags : Tag[] = [];

  constructor(private _tagService: TagService,
    private _activateRoute: ActivatedRoute,
    private _dialog: MatDialog,
    private _router: Router) { }

  ngOnInit(): void {

    this._activateRoute.paramMap.subscribe(params => {
      this.articleId = Number(params.get('articleid'));

      this.LoadData();
    })  
  }

  LoadData() {
    this._tagService.getByArticleId(this.articleId)
      .subscribe(tags => this.tags = tags);
  }

  getArticlesByTag(tag: Tag) {
    this._router.navigate(
      ['/search'], 
      {
          queryParams:{
              'tag': tag.text
          }
      }
    );
  }

  removeTag(tag: Tag) {
    this._tagService.removeTag(this.articleId, tag.text)
      .subscribe(() => this.ngOnInit());
  }

  private addTag(tagName: string) {
    return this._tagService.addTag(this.articleId, tagName);
  }

  openAddTagDialog() {
    const dialogRef = this._dialog.open(TagAddDialogComponent,{
      data: {tagName: ''}
    });

    dialogRef.afterClosed().subscribe(tagName => {
      this.addTag(tagName)
        .subscribe(() => this.ngOnInit());
    });
  }
}
