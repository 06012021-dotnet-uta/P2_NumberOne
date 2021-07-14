import { Injectable } from '@angular/core';
import { LoginComponent } from './login/login';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient, private messageService: MessageService) { }

  private loginUrl = 'api/Login'; //Grabbed uri string from api

  loginRequest(): Observable <Customer> {
    return this.http.post<Customer>(this.loginUrl)
    .pipe(
      catchError(this.handleError<Customer>('loginRequest', []))
    );
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  } 
}
