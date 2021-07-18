import { Component, OnInit, Input, Output } from '@angular/core';
import { Forum } from '../Forum';
import { ForumserviceService } from '../forumservice.service';


@Component({
  selector: 'app-forum-list',
  templateUrl: './forum-list.component.html',
  styleUrls: ['./forum-list.component.css']
})
export class ForumListComponent implements OnInit {

  @Input()forumobj!: Forum;

  constructor(private forumservice: ForumserviceService) { 
       
  }

  ngOnInit(): void {
  }

 deleteForum(forumID: number){
   this.forumservice.DeletedForum(forumID).subscribe();
 };

}
