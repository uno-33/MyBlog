import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ArticleCreateFormComponent } from './article-create-form/article-create-form.component';
import { ArticleDeletePageComponent } from './article-delete-page/article-delete-page.component';
import { ArticleEditFormComponent } from './article-edit-form/article-edit-form.component';
import { ArticlePageComponent } from './article-page/article-page.component';
import { BlogCreateFormComponent } from './blog-create-form/blog-create-form.component';
import { BlogDeletePageComponent } from './blog-delete-page/blog-delete-page.component';
import { BlogEditFormComponent } from './blog-edit-form/blog-edit-form.component';
import { BlogPageComponent } from './blog-page/blog-page.component';
import { LatestBlogsComponent } from './latest-blogs/latest-blogs.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { SearchPageComponent } from './search-page/search-page.component';
import { AuthGuard } from './_helpers/auth.guard';

const routes: Routes = [
  { path: '', component: LatestBlogsComponent, pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'blogs/new', component: BlogCreateFormComponent, canActivate: [AuthGuard] },
  { path: 'blogs/:id', component: BlogPageComponent },
  { path: 'blogs/:id/edit', component: BlogEditFormComponent, canActivate: [AuthGuard] },
  { path: 'blogs/:id/delete', component: BlogDeletePageComponent, canActivate: [AuthGuard] },
  { path: 'blogs/:id/articles/new', component: ArticleCreateFormComponent, canActivate: [AuthGuard] },
  { path: 'blogs/:id/articles/:articleid', component: ArticlePageComponent },
  { path: 'blogs/:id/articles/:articleid/edit', component: ArticleEditFormComponent, canActivate: [AuthGuard] },
  { path: 'blogs/:id/articles/:articleid/delete', component: ArticleDeletePageComponent, canActivate: [AuthGuard] },
  { path: 'search', component: SearchPageComponent },
  { path: '**', redirectTo: '/'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
