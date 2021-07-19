import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Forum } from '../Forum';
import { ForumserviceService } from '../forumservice.service';
import { Post, PostService } from '../post.service';

@Component({
  selector: 'app-forum-posts-list',
  templateUrl: './forum-posts-list.component.html',
  styleUrls: ['./forum-posts-list.component.css']
})
export class ForumPostsListComponent implements OnInit {

  constructor(private postService: PostService, private forumService: ForumserviceService, private router: Router) { }

  ForumId: number = 1;
  Forum!: Forum;

  ListOfPosts: Post[] = [];

  ngOnInit(): void {
    this.ForumId = Number(this.router.url.split('/')[2]);
    this.postService.GetPostList(this.ForumId.toString()).subscribe(
      x => this.ListOfPosts = x
    );

    this.forumService.SearchForum(this.ForumId).subscribe(
      (x) => this.Forum = x
    );
  }

  getPostCoords(): number[][]
  {
    let coordArray: number[][] = [];
    this.ListOfPosts.forEach(post => {
      coordArray.push([post.locationLatitude, post.locationLongitude])
    });
    return coordArray;
  }
}
