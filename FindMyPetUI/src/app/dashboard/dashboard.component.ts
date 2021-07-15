import { Component, OnInit } from '@angular/core';
import { BreedListService, Breed } from '../breedList.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { Observable, of } from 'rxjs';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor(private breedListService: BreedListService) { 
    this.ListofBreeds = [];

  }

  ListofBreeds: Breed[];

  ngOnInit(): void {

  }

  onSubmit()
  {
    //this.ListofBreeds = this.breedListService.GetBreedList();
    this.breedListService.GetBreedList().subscribe
    (
      ListofBreeds => this.ListofBreeds = ListofBreeds
    )
  }   

}


