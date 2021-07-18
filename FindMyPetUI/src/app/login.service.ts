import { Injectable } from '@angular/core';
import { LoginComponent } from './login/login.component';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
import { Observable, of, throwError } from 'rxjs';
import { Globals } from './globals';
import { NGXLogger } from "ngx-logger";
import { Customer } from './customer/customer';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class LoginService 
{

  constructor(private http: HttpClient, private global: Globals, private router: Router) { }

  httpHeader = 
  {
    headers: new HttpHeaders
    ({
      'Content-Type': 'application/json',
      'url' : ''
    })
  }

  private loginUrl = 'api/Customer/Login';

  loginRequest(Info: UserInfo)
  {
    console.log("Data: ", Info);
    this.http.post(this.global.currentHostURL()+this.loginUrl, Info, this.httpHeader)
    .subscribe
    (
      (data) => 
      {
        console.log(data);
        this.router.navigate(['']);
        return data as Customer;
      },
      (error) => 
      {
        console.log(error)
      }
    );
  }
}

export class UserInfo
{
  constructor(
    public username: string,
    public password: string
  ) {}
}