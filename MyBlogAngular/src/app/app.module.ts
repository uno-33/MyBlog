import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule, HttpHandler, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { LoginComponent } from './login/login.component';
import { AuthInterceptor } from 'src/app/_helpers/auth.interceptor';
import { LatestArticlesComponent } from './latest-articles/latest-articles.component';
import { SearchBoxComponent } from './search-box/search-box.component';
import { LatestBlogsComponent } from './latest-blogs/latest-blogs.component';
import { BlogPageComponent } from './blog-page/blog-page.component';
import { BlogCreateFormComponent } from './blog-create-form/blog-create-form.component';
import { TruncatePipe } from './truncate.pipe';
import { BlogEditFormComponent } from './blog-edit-form/blog-edit-form.component';
import { BlogDeletePageComponent } from './blog-delete-page/blog-delete-page.component';
import { ArticlePageComponent } from './article-page/article-page.component';
import { ArticleCreateFormComponent } from './article-create-form/article-create-form.component';
import { ArticleDeletePageComponent } from './article-delete-page/article-delete-page.component';
import { ArticleEditFormComponent } from './article-edit-form/article-edit-form.component';
import { CommentListComponent } from './comment-list/comment-list.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDialogModule, MAT_DIALOG_DEFAULT_OPTIONS } from '@angular/material/dialog';
import { CommentEditDialogComponent } from './comment-edit-dialog/comment-edit-dialog.component';
import { CommentDeleteDialogComponent } from './comment-delete-dialog/comment-delete-dialog.component';
import { TagListComponent } from './tag-list/tag-list.component';
import { TagAddDialogComponent } from './tag-add-dialog/tag-add-dialog.component';
import { SearchPageComponent } from './search-page/search-page.component';
import { ErrorInterceptor } from './_helpers/error.interceptor';
import { RegisterComponent } from './register/register.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    LoginComponent,
    LatestArticlesComponent,
    SearchBoxComponent,
    LatestBlogsComponent,
    BlogPageComponent,
    BlogCreateFormComponent,
    TruncatePipe,
    BlogEditFormComponent,
    BlogDeletePageComponent,
    ArticlePageComponent,
    ArticleCreateFormComponent,
    ArticleDeletePageComponent,
    ArticleEditFormComponent,
    CommentListComponent,
    CommentEditDialogComponent,
    CommentDeleteDialogComponent,
    TagListComponent,
    TagAddDialogComponent,
    SearchPageComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatDialogModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    { provide: MAT_DIALOG_DEFAULT_OPTIONS, useValue: {hasBackdrop: false}},
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
