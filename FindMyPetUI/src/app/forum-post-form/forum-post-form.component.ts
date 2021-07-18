import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { CreatePostRequest, Post, PostService } from '../post.service';

@Component({
  selector: 'app-forum-post-form',
  templateUrl: './forum-post-form.component.html',
  styleUrls: ['./forum-post-form.component.css']
})
export class ForumPostFormComponent implements OnInit {

  constructor(private postService: PostService, private router: Router) { 
  }

  postModel: PostModel = {};

  post: Post | undefined = undefined;

  ngOnInit(): void {
  }

  onSubmit()
  {
    let newPostForumId: string = this.router.url.split('/')[2];
    let post: CreatePostRequest = {
      posterId: 0,
      forumId: parseInt(newPostForumId),
      locationLatitude: this.postModel.locationLatitude!,
      locationLongitude: this.postModel.locationLongitude!,
      textBody: this.postModel.textBody!
    }
    console.log(post);
    this.postService.CreatePost(newPostForumId, post).subscribe( x => this.post = x);
  }

  
}

interface PostModel
{
  locationLatitude?: number,
  locationLongitude?: number,
  textBody?: string
}
