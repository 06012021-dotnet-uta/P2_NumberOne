import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { Globals } from './globals';
import { NGXLogger } from "ngx-logger";
import { Forum } from './Forum';

@Injectable({
  providedIn: 'root'
})
export class ForumserviceService {

  ForumListUrl = 'api/Forum/ForumList';
  ForumDeleteUrl = '​api/Forum/DeleteForum/'
  ForumAddUrl = 'api/Forum/NewForum'

  constructor(private http: HttpClient, private global: Globals) { }

  private loginUrl = 'https://localhost:44396/' + 'api/Login';

  // Fuction only
  GetForumList(): Observable<Forum[]> {
    return this.http.get<Forum[]>(this.global.currentHostURL() + this.ForumListUrl)
      
  } 

   AddForum(forumObj: Forum): Observable<Forum> {
     return this.http.post<Forum>(`${this.global.localHost}` + `${this.ForumAddUrl}`, forumObj)
  };

  DeletedForum(forumID: number){
     return this.http.get('https://localhost:44396/api/Forum/DeleteForum/' + forumID)
  }

  // SearchForum(forumId: number){
  //   return this.http.get('https://localhost:44396/api/Forum/ForumDetails/' + forumId)
  // }


}
