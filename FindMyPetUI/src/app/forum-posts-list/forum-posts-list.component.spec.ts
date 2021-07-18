import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ForumPostsListComponent } from './forum-posts-list.component';

describe('ForumPostsListComponent', () => {
  let component: ForumPostsListComponent;
  let fixture: ComponentFixture<ForumPostsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ForumPostsListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ForumPostsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
