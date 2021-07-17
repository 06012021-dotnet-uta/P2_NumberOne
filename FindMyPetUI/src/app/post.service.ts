import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Globals } from './globals';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private http: HttpClient, private global: Globals) { }

  ForumUrl = 'api/forum/';
  PostListUrl = '/posts/list';
  PostCreateUrl = '/posts/create';

  SelectedPost: Post | undefined = undefined;

  GetPostList(forumId: string): Observable<Post[]>{
    return this.http.get<Post[]>(this.global.currentHostURL() + this.ForumUrl + forumId + this.PostListUrl);
  }

  CreatePost(forumId: string, post: CreatePostRequest): Observable<Post>{
    return this.http.post<Post>(this.global.currentHostURL() + this.ForumUrl + forumId + this.PostCreateUrl, post);
  }
}

export interface CreatePostRequest
{
  posterId: number,
  replyId?: number,
  forumId: number,
  locationLatitude: number,
  locationLongitude: number,
  textBody: string
}

export interface Post
{
  postId: number,
  posterId: number,
  replyId: number,
  forumId: number,
  locationLatitude: number,
  locationLongitude: number,
  textBody: string,
  postTime: Date
}
