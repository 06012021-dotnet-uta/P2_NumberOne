import { Injectable } from "@angular/core";
import { NGXLogger } from "ngx-logger";


@Injectable()
export class Globals 
{

  localHost = 'https://localhost:44396/';
  publicHost = 'http://temp.url/';
  currentHostURL = 'https://localhost:44396/';

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  // var handleError<T>(operation = 'operation', result?: T) {
  //   return (error: any): Observable<T> => {

  //     // TODO: send the error to remote logging infrastructure
  //     console.error(error); // log to console instead

  //     // TODO: better job of transforming error for user consumption
  //     this.log(`${operation} failed: ${error.message}`);

  //     // Let the app keep running by returning an empty result.
  //     return of(result as T);
  //   };

}