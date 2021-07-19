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

  filterForums(search : string)
  {
    if(search == "")
      this.ngOnInit();
    else
    {
      this.ListofForum = this.ListofForum.filter(x => {
        return x.forumName.toLowerCase().match(search.toLowerCase());
      })
    }
  }

}
