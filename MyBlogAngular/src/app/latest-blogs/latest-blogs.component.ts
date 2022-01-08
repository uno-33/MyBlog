import { Component, OnInit } from '@angular/core';
import { Blog } from '../models/blog';
import { BlogService } from '../services/blog/blog.service';

@Component({
  selector: 'app-latest-blogs',
  templateUrl: './latest-blogs.component.html',
  styleUrls: ['./latest-blogs.component.css']
})
export class LatestBlogsComponent implements OnInit {

  blogs: Blog[] = [];
  constructor(private _blogService : BlogService) { }

  ngOnInit(): void {
    this._blogService.getLatest().subscribe(blogs => this.blogs = blogs);
  }

}
