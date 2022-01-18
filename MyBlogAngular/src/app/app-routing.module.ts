import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ArticleCreateFormComponent } from './article-create-form/article-create-form.component';
import { ArticlePageComponent } from './article-page/article-page.component';
import { BlogCreateFormComponent } from './blog-create-form/blog-create-form.component';
import { BlogDeletePageComponent } from './blog-delete-page/blog-delete-page.component';
import { BlogEditFormComponent } from './blog-edit-form/blog-edit-form.component';
import { BlogListComponent } from './blog-list/blog-list.component';
import { BlogPageComponent } from './blog-page/blog-page.component';
import { LatestBlogsComponent } from './latest-blogs/latest-blogs.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  { path: '', component: LatestBlogsComponent, pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'blogs/new', component: BlogCreateFormComponent },
  { path: 'blogs/:id', component: BlogPageComponent },
  { path: 'blogs/:id/edit', component: BlogEditFormComponent },
  { path: 'blogs/:id/delete', component: BlogDeletePageComponent },
  { path: 'blogs/:id/articles/new', component: ArticleCreateFormComponent },
  { path: 'blogs/:id/articles/:articleid', component: ArticlePageComponent }
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
