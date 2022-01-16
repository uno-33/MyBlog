import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiPaths } from 'src/apipaths';
import { BlogService } from '../services/blog/blog.service';

@Component({
  selector: 'app-blog-create-form',
  templateUrl: './blog-create-form.component.html',
  styleUrls: ['./blog-create-form.component.css']
})
export class BlogCreateFormComponent implements OnInit {

  createBlogForm:FormGroup;
  
  constructor(private fb:FormBuilder, private _blogService : BlogService, private _router: Router) { 
    this.createBlogForm = fb.group({
      name: ['', Validators.required],
      description: ['', Validators.required]
    });
  }

  ngOnInit(): void {
  }

  onSubmit() {
    const val = this.createBlogForm.value;

    if(val.name && val.description) {
      this._blogService.create(val.name, val.description)
      .subscribe(blog => {
        this._router.navigate([ApiPaths.Blogs, blog.id]);
      })
    }
  }
}
