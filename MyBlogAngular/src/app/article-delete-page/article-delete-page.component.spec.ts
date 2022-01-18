import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArticleDeletePageComponent } from './article-delete-page.component';

describe('ArticleDeletePageComponent', () => {
  let component: ArticleDeletePageComponent;
  let fixture: ComponentFixture<ArticleDeletePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ArticleDeletePageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ArticleDeletePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
