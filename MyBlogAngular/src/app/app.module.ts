import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule, HttpHandler, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { BlogListComponent } from './blog-list/blog-list.component';
import { LoginComponent } from './login/login.component';
import { AuthInterceptor } from 'src/Interceptors/auth.interceptor';
import { LatestArticlesComponent } from './latest-articles/latest-articles.component';
import { SearchBoxComponent } from './search-box/search-box.component';
import { LatestBlogsComponent } from './latest-blogs/latest-blogs.component';
import { BlogPageComponent } from './blog-page/blog-page.component';
import { BlogCreateFormComponent } from './blog-create-form/blog-create-form.component';
import { TruncatePipe } from './truncate.pipe';
import { BlogEditFormComponent } from './blog-edit-form/blog-edit-form.component';
import { BlogDeletePageComponent } from './blog-delete-page/blog-delete-page.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    BlogListComponent,
    LoginComponent,
    LatestArticlesComponent,
    SearchBoxComponent,
    LatestBlogsComponent,
    BlogPageComponent,
    BlogCreateFormComponent,
    TruncatePipe,
    BlogEditFormComponent,
    BlogDeletePageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
