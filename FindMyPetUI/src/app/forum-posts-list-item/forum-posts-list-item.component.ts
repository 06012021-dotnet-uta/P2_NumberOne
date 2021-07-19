import { Component, Input, OnInit } from '@angular/core';
import { Post, PostService } from '../post.service';
import {Router} from '@angular/router'

@Component({
  selector: 'app-forum-posts-list-item',
  templateUrl: './forum-posts-list-item.component.html',
  styleUrls: ['./forum-posts-list-item.component.css']
})
export class ForumPostsListItemComponent implements OnInit {
  
  constructor(private router: Router, private postService: PostService) {}

  @Input() post!: Post;

  ngOnInit(): void {}

  onSubmit()
  {
    this.postService.DeletePost(this.post.postId).subscribe(
      () => window.location.reload()
    )
  }

  returnDate(): string
  {
    return new Date(this.post.postTime).toDateString();
  }
}
