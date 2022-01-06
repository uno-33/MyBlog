import { Component, OnInit } from '@angular/core';
import { Blog } from '../models/blog';
import { BlogListService } from '../services/blog-list.service';

@Component({
  selector: 'app-blog-list',
  templateUrl: './blog-list.component.html',
  styleUrls: ['./blog-list.component.css']
})
export class BlogListComponent implements OnInit {

  blogs: Blog[] = [];
  constructor(private _blogListService: BlogListService) {
   }

  ngOnInit(): void {
    this._blogListService.getBlogs().subscribe(blogs => this.blogs = blogs);
  }

}
