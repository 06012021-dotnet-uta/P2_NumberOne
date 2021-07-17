import { Injectable } from "@angular/core";
import { NGXLogger } from "ngx-logger";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';


@Injectable({providedIn: 'root'})
export class Globals 
{

  localHost: string = 'https://localhost:44396/';
  publicHost: string = 'http://temp.url/';
  currentURL: string = this.localHost;

  currentHostURL() {
    return this.currentURL;
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  handleError<T>(operation = 'operation', result?: T) 
  {
    return (error: any): Observable<T> => 
      {

        // TODO: send the error to remote logging infrastructure
        console.error(error); // log to console instead

        // TODO: better job of transforming error for user consumption
        //this.log(`${operation} failed: ${error.message}`);

        // Let the app keep running by returning an empty result.
        return of(result as T);
      }
  };

}