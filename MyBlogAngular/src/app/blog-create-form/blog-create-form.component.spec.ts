import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BlogCreateFormComponent } from './blog-create-form.component';

describe('BlogCreateFormComponent', () => {
  let component: BlogCreateFormComponent;
  let fixture: ComponentFixture<BlogCreateFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BlogCreateFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BlogCreateFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
