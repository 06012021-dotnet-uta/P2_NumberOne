import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap, retry } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { Globals } from './globals';


@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http: HttpClient, private global: Globals) { }

  CategoryUrl = 'api/Category/List';

  GetCategoryList(): Observable<CategoryInteface[]> {
    return this.http.get<CategoryInteface[]>(this.global.currentHostURL()+this.CategoryUrl)
  } 
}
export interface CategoryInteface {
  categoryId:number;
  type:string;
}
