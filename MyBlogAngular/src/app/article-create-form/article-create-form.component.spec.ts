import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArticleCreateFormComponent } from './article-create-form.component';

describe('ArticleCreateFormComponent', () => {
  let component: ArticleCreateFormComponent;
  let fixture: ComponentFixture<ArticleCreateFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ArticleCreateFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ArticleCreateFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
