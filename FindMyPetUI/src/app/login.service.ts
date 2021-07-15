import { Injectable } from '@angular/core';
import { LoginComponent } from './login/login.component';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { Globals } from './globals';
import { NGXLogger } from "ngx-logger";
import { Customer } from './customer/customer';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient) { }

  private loginUrl = 'https://localhost:44396/' + 'api/Login'; //Grabbed uri string from api

  loginRequest(): Observable<any> {
    return this.http.post<any>(this.loginUrl, {title: 'Login Request'})
    .pipe(
      //catchError(Globals.handleError<Customer>('loginRequest', null, []))
    );
  } 
}