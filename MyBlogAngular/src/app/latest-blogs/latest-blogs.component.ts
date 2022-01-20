import { Component, OnInit } from '@angular/core';
import { Blog } from '../_models/blog';
import { BlogService } from '../services/blog/blog.service';
import { AuthService } from '../services/auth/auth.service';

@Component({
  selector: 'app-latest-blogs',
  templateUrl: './latest-blogs.component.html'
})
export class LatestBlogsComponent implements OnInit {

  blogs: Blog[] = [];
  constructor(private _blogService : BlogService, private _authService: AuthService) { }

  ngOnInit(): void {
    this._blogService.getLatest().subscribe(blogs => this.blogs = blogs);
  }

  public isAccessible() {
    if(this._authService.isLoggedIn())
      return true;

    return false;
  }

}
