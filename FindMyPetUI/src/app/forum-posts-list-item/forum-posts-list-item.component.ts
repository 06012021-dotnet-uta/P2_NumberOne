import { Component, Input, OnInit } from '@angular/core';
import { Post } from '../post.service';
import {Router} from '@angular/router'

@Component({
  selector: 'app-forum-posts-list-item',
  templateUrl: './forum-posts-list-item.component.html',
  styleUrls: ['./forum-posts-list-item.component.css']
})
export class ForumPostsListItemComponent implements OnInit {
  
  constructor(private router: Router) {}

  @Input() post!: Post;

  ngOnInit(): void {}

  onSubmit()
  {
  }
}
