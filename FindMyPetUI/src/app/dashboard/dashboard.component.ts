import { Component, OnInit } from '@angular/core';
import { BreedListService, Breed } from '../breedList.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Router } from '@angular/router';
import { Forum } from '../Forum';
import { ForumserviceService } from '../forumservice.service';
import { LoginService } from '../login.service';
import { Customer } from '../customer/customer';
import { ThisReceiver } from '@angular/compiler';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor(private breedListService: BreedListService, private forumservice: ForumserviceService, private login: LoginService) { 
    this.ListofBreeds = [];
    this.ListofForum = [];
    this.user = new Customer;
  }

  user: Customer;

  ListofBreeds: Breed[];
  ListofForum: Forum[];

  ngOnInit(): void {

  }

  onSubmit()
  {
    this.breedListService.GetBreedList()
    .subscribe
    (
      ListofBreeds => this.ListofBreeds = ListofBreeds
    )
  }   

  getForumList(){
    this.forumservice.GetForumList().subscribe
    (
      ListofForum => this.ListofForum = ListofForum
    )
  }

}


