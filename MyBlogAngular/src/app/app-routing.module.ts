import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BlogCreateFormComponent } from './blog-create-form/blog-create-form.component';
import { BlogListComponent } from './blog-list/blog-list.component';
import { BlogPageComponent } from './blog-page/blog-page.component';
import { LatestBlogsComponent } from './latest-blogs/latest-blogs.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  { path: '', component: LatestBlogsComponent, pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'blogs/new', component: BlogCreateFormComponent },
  { path: 'blogs/:id', component: BlogPageComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
