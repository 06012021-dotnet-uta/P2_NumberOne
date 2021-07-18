import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ForumPostsListItemComponent } from './forum-posts-list-item.component';

describe('ForumPostsListItemComponent', () => {
  let component: ForumPostsListItemComponent;
  let fixture: ComponentFixture<ForumPostsListItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ForumPostsListItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ForumPostsListItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
