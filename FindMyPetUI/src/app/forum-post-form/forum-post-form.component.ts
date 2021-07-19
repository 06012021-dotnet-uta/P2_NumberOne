import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Globals } from '../globals';
import { CreatePostRequest, Post, PostService } from '../post.service';

@Component({
  selector: 'app-forum-post-form',
  templateUrl: './forum-post-form.component.html',
  styleUrls: ['./forum-post-form.component.css']
})
export class ForumPostFormComponent implements OnInit {

  constructor(private postService: PostService, private router: Router, private global: Globals) { 
  }

  postModel: PostModel = {};

  //post: Post | undefined = undefined;

  ngOnInit(): void {}

  onSubmit()
  {
    let newPostForumId: string = this.router.url.split('/')[2];
    let post: CreatePostRequest = {
      posterId: 0, //posterId: global.currentLoggedInCustomer,
      forumId: parseInt(newPostForumId),
      locationLatitude: this.postModel.locationLatitude!,
      locationLongitude: this.postModel.locationLongitude!,
      textBody: this.postModel.textBody!
    }

    this.postService.CreatePost(newPostForumId, post).subscribe( 
      x => post = x, 
      (error) => console.log(error),
      () => this.router.navigate(['../forum', post.forumId, 'posts'])
    );

    
  }

  setCoords(selectedCoords: number[])
  {
    this.postModel.locationLatitude = selectedCoords[0];
    this.postModel.locationLongitude = selectedCoords[1];
  }

  
}

interface PostModel
{
  locationLatitude?: number,
  locationLongitude?: number,
  textBody?: string
}
