import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap, retry } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { Globals } from './globals';


@Injectable({
  providedIn: 'root'
})
export class AggressionService {

  constructor(private http: HttpClient, private global: Globals) { }

  AggressionUrl = 'api/Pet/AggressionList';

  GetAggressionList(): Observable<AggressionInteface[]> {
    return this.http.get<AggressionInteface[]>(this.global.currentHostURL()+this.AggressionUrl)
  } 
}
export interface AggressionInteface {
  code:number;
  descriptor:string;
}
