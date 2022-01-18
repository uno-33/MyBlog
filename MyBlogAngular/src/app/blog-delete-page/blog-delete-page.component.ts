import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { switchMap } from 'rxjs';
import { ApiPaths } from 'src/apipaths';
import { BlogService } from '../services/blog/blog.service';

@Component({
  selector: 'app-blog-delete-page',
  templateUrl: './blog-delete-page.component.html',
  styleUrls: ['./blog-delete-page.component.css']
})
export class BlogDeletePageComponent implements OnInit {

  deleteBlogForm:FormGroup;
  blogId: number = 0;
  
  constructor(
    private fb:FormBuilder, 
    private _blogService : BlogService, 
    private _router: Router, 
    private _activatedRoute: ActivatedRoute) { 

    this.deleteBlogForm = fb.group({
      name: [{ value: '', disabled: true }, Validators.required],
      description: [{ value: '', disabled: true }, Validators.required]
    });
  }

  ngOnInit(): void {

    this._activatedRoute.paramMap.pipe(
      switchMap(params => params.getAll('id'))
    )
    .subscribe(data => this.blogId = +data);
    
    this._blogService.getById(this.blogId)
      .subscribe(blog => {
        this.deleteBlogForm.setValue({
          name: blog.name,
          description: blog.description
        });
      });
  }

  onSubmit() {

    this._blogService.delete(this.blogId)
    .subscribe(blog => {
      this._router.navigate(['/']);
    })
  }

}
