import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import {  GenderInteface, GenderService } from '../gender.service';


@Component({
  selector: 'app-gender',
  templateUrl: './gender.component.html',
  styleUrls: ['./gender.component.css']
})
export class GenderComponent implements OnInit {


  
      
  



  constructor(private GenderListService: GenderService) { 
    this.ListofGender = [];

  }

  ListofGender: GenderInteface[];

  ngOnInit(): void {
     //this.ListofBreeds = this.breedListService.GetBreedList();
     this.GenderListService.GetGenderList().subscribe
     (
       ListofGender => this.ListofGender = ListofGender
     )

  }




  onSubmit()
  {
  
  }   

}
