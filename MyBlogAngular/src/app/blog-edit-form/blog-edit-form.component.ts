import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { switchMap } from 'rxjs/internal/operators/switchMap';
import { ApiPaths } from 'src/apipaths';
import { Blog } from '../models/blog';
import { BlogService } from '../services/blog/blog.service';

@Component({
  selector: 'app-blog-edit-form',
  templateUrl: './blog-edit-form.component.html',
  styleUrls: ['./blog-edit-form.component.css']
})
export class BlogEditFormComponent implements OnInit {

  editBlogForm:FormGroup;
  blogId: number = 0;
  
  constructor(
    private fb:FormBuilder, 
    private _blogService : BlogService, 
    private _router: Router, 
    private _activatedRoute: ActivatedRoute) { 

    this.editBlogForm = fb.group({
      name: ['', Validators.required],
      description: ['', Validators.required]
    });
  }

  ngOnInit(): void {

    this._activatedRoute.paramMap.pipe(
      switchMap(params => params.getAll('id'))
    )
    .subscribe(data => this.blogId = +data);
    
    this._blogService.getById(this.blogId)
      .subscribe(blog => {
        this.editBlogForm.setValue({
          name: blog.name,
          description: blog.description
        });
      });
  }

  onSubmit() {
    const val = this.editBlogForm.value;

    if(val.name && val.description) {
      this._blogService.edit(this.blogId, val.name, val.description)
      .subscribe(blog => {
        this._router.navigate([ApiPaths.Blogs, blog.id]);
      })
    }
  }

}
