import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import {  GenderInteface, GenderService } from '../gender.service';
import { AggressionInteface, AggressionService } from '../aggression.service';


@Component({
  selector: 'app-aggression',
  templateUrl: './aggression.component.html',
  styleUrls: ['./aggression.component.css']
})
export class AggressionComponent implements OnInit {

  constructor(private AggressionListService: AggressionService) { 
    this.ListofAggression = [];

  }

  ListofAggression: AggressionInteface[];

  ngOnInit(): void {
    this.AggressionListService.GetAggressionList().subscribe
    (
      ListofAggression => this.ListofAggression = ListofAggression
    )
  }

  onSubmit()
  {
    //this.ListofBreeds = this.breedListService.GetBreedList();

  }   

}
