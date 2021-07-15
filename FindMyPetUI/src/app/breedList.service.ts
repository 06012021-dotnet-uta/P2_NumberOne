import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap, retry } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { Globals } from './globals';

@Injectable({
  providedIn: 'root'
})
export class BreedListService {

  constructor(private http: HttpClient, private global: Globals) { }

  BreedUrl = 'api/Breed/List';

  GetBreedList(): Observable<Breed[]> {
    return this.http.get<Breed[]>(this.global.currentHostURL()+this.BreedUrl)
      // .pipe(
      //   tap(_ => this.log('fetched breeds')),
      //   catchError(this.handleError<Breed[]>('getBreedList', []))
      // );
  } 
}

export interface Breed
{
    breedId: number,
    categoryId: number,
    breed1: string,
    category: null
}