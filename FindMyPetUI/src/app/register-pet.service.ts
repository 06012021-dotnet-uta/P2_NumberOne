import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap, retry } from 'rxjs/operators';
import { Observable, of as observableOf} from 'rxjs';
import { Globals } from './globals';
import { RegisterCustomer } from './register-customer';

@Injectable({
  providedIn: 'root'
})
export class RegisterPetService {

  /* This if you want to use httpOptions when you post the data to the database
  httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}*/


  constructor(private http: HttpClient, private global: Globals) { }
  
  
  
  
  public  addPet(petObj: RegisterPet) {
  return this.http.post(`${this.global.localHost}api/Pet/Register/`,petObj);  //if you want you can add one more parameter httpOptions from the httpOptions commented above 
  }

  GenderUrl = 'api/Pet/GenderList';
  GetGenderList(): Observable<GenderInteface[]> {
    return this.http.get<GenderInteface[]>(this.global.currentHostURL()+this.GenderUrl)
  }

  
  
  AggressionUrl = 'api/Pet/AggressionList';
  GetAggressionList(): Observable<AggressionInteface[]> {
    return this.http.get<AggressionInteface[]>(this.global.currentHostURL()+this.AggressionUrl)
  } 
  

  CategoryUrl = 'api/Category/List';
  GetCategoryList(): Observable<CategoryInteface[]> {
    return this.http.get<CategoryInteface[]>(this.global.currentHostURL()+this.CategoryUrl)
  } 
} 

export interface RegisterPet {
  petid: number;
  ownerid: number;
  aggressioncode: number;
  name: string;
  category: number;
  gender: number;
  age: number;
}

export interface GenderInteface {
  code:number;
  gender1:string;
}

export interface CategoryInteface {
  categoryId:number;
  type:string;
}


export interface AggressionInteface {
  code:number;
  descriptor:string;
}

