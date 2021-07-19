import { Component, OnInit, Input, Output, OnChanges } from '@angular/core';
import { Forum } from '../Forum';
import { ForumserviceService } from '../forumservice.service';
import { ForumHeaderComponent } from '../forum-header/forum-header.component';


@Component({
  selector: 'app-forum-list',
  templateUrl: './forum-list.component.html',
  styleUrls: ['./forum-list.component.css']
})
export class ForumListComponent implements OnInit, OnChanges {

  @Input() forumobj!: Forum;
  @Input() data: ForumHeaderComponent | undefined;
 

  constructor(private forumservice: ForumserviceService) { 
    this.ListofForum = [];
  }

  ngOnInit(){}
  
  ListofForum: Forum[];

 ngOnChanges(){
   if(this.data?.forumName == ""){
     this.forumservice.GetForumList().subscribe(
      x => this.ListofForum = x
     )
   }else{
     this.ListofForum.filter(
       y => {return y.forumName.toLowerCase().match(this.data?.forumName.toLowerCase())} )
   }
 }

 deleteForum(forumID: number){
   this.forumservice.DeletedForum(forumID).subscribe(
     () => window.location.reload()
   );
 };




}
