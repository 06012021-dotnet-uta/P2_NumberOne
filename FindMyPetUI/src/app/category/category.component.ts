import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { CategoryInteface, RegisterPetService,  } from '../register-pet.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})export class CategoryComponent implements OnInit {

  constructor(private CategoryListService: RegisterPetService) { 
    this.ListofCategory = [];

  }

  ListofCategory: CategoryInteface[];

  ngOnInit(): void {
    this.CategoryListService.GetCategoryList().subscribe
    (
      ListofCategory => this.ListofCategory = ListofCategory
    )

  }

  onSubmit()
  {
    //this.ListofBreeds = this.breedListService.GetBreedList();
   
  }   

}
