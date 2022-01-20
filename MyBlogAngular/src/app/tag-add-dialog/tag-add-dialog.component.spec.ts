import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TagAddDialogComponent } from './tag-add-dialog.component';

describe('TagAddDialogComponent', () => {
  let component: TagAddDialogComponent;
  let fixture: ComponentFixture<TagAddDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TagAddDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TagAddDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
