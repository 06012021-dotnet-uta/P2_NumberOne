import { Component, Input, OnInit } from '@angular/core';
import { Post, PostService } from '../post.service';

@Component({
  selector: 'app-forum-posts-list',
  templateUrl: './forum-posts-list.component.html',
  styleUrls: ['./forum-posts-list.component.css']
})
export class ForumPostsListComponent implements OnInit {

  constructor(private postService: PostService) { }

  @Input() ForumId: number = 1;

  ListOfPosts: Post[] = [];

  ngOnInit(): void {
    this.postService.GetPostList(this.ForumId.toString()).subscribe(
      x => this.ListOfPosts = x
    );
  }

  onSubmit(postId: number){
    console.log("Button Pressed: " + postId);
  }

}
