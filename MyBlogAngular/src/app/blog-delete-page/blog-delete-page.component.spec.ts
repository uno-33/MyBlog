import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BlogDeletePageComponent } from './blog-delete-page.component';

describe('BlogDeletePageComponent', () => {
  let component: BlogDeletePageComponent;
  let fixture: ComponentFixture<BlogDeletePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BlogDeletePageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BlogDeletePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
