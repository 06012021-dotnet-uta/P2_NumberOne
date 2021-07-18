import { Component, OnInit } from '@angular/core';
import { Forum } from '../Forum';
import { ForumserviceService } from '../forumservice.service';

@Component({
  selector: 'app-forum',
  templateUrl: './forum.component.html',
  styleUrls: ['./forum.component.css']
})
export class ForumComponent implements OnInit {

  constructor(private forumservice: ForumserviceService) { 
    this.ListofForum = [];
  }

  ListofForum: Forum[];

  ngOnInit(): void {

    this.forumservice.GetForumList().subscribe(

      ListofForum => this.ListofForum = ListofForum
      
    );

  }

}
