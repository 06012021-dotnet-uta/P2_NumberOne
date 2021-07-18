import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap, retry } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { Globals } from './globals';


@Injectable({
  providedIn: 'root'
})
export class GenderService {

  constructor(private http: HttpClient, private global: Globals) { }

  GenderUrl = 'api/Pet/GenderList';

  GetGenderList(): Observable<GenderInteface[]> {
    return this.http.get<GenderInteface[]>(this.global.currentHostURL()+this.GenderUrl)
      // .pipe(
      //   tap(_ => this.log('fetched breeds')),
      //   catchError(this.handleError<Breed[]>('getBreedList', []))
      // );
  } 
}
export interface GenderInteface {
  code:number;
  gender1:string;
}
