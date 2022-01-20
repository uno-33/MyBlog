import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { switchMap } from 'rxjs';
import { Tag } from '../_models/tag';
import { TagAddDialogComponent } from '../tag-add-dialog/tag-add-dialog.component';
import { TagService } from '../services/tag/tag.service';
import { AuthService } from '../services/auth/auth.service';
import { ArticleService } from '../services/article/article.service';

@Component({
  selector: 'app-tag-list',
  templateUrl: './tag-list.component.html'
})
export class TagListComponent implements OnInit {

  articleId = 0;
  authorId: string = '';
  tags : Tag[] = [];

  constructor(private _tagService: TagService,
    private _activateRoute: ActivatedRoute,
    private _dialog: MatDialog,
    private _router: Router,
    public _authService: AuthService,
    private _articleService: ArticleService) { }

  ngOnInit(): void {

    this._activateRoute.paramMap.subscribe(params => {
      this.articleId = Number(params.get('articleid'));

      this.LoadData();
    })  
  }

  LoadData() {
    this._tagService.getByArticleId(this.articleId)
      .subscribe(tags => this.tags = tags);

    this._articleService.getById(this.articleId)
      .subscribe(article => this.authorId = article.creatorId);
  }

  public isAccessible() {
    if(this._authService.isOwner(this.authorId) || this._authService.isAdmin())
      return true;

    return false;
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
