import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from "@angular/router";

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Globals } from './globals';
import { Customer } from './customer/customer';
import { Observable, of} from 'rxjs';
import { Router } from '@angular/router';


@Injectable({
  providedIn: 'root'
})

export class AuthService implements CanActivate{

  constructor( private global: Globals, private router: Router, private http: HttpClient) 
  {
    this.user = new Customer();
    this.sessionUser = new Customer();
  }

  user: Customer;
  sessionUser: Customer;

  canActivate
  (
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree 
  {
    if(this.ValidUserToken())
    {
      return true;
    }
    else
    {
      this.router.navigate(['login'], { queryParams: { returnUrl: state.url } });
      return false;
    }
  }

  ValidUserToken(): boolean
  {
    let httpHeader = 
    {
      headers: new HttpHeaders
      ({
        'Content-Type': 'application/json'
      })
    }

    if(localStorage.getItem("PetUserSessionToken") === null || localStorage.getItem("PetUserSessionToken") == undefined)
    {
      return false;
    }
    else
    {
      console.log(localStorage.getItem("PetUserSessionToken"));
      //this.sessionUser = JSON.parse(localStorage.getItem("PetUserSessionToken")!);
      let tokenUser = {
        username: this.sessionUser.username,
        password: this.sessionUser.password
      }

      this.http.post(this.global.currentHostURL()+'api/Customer/Login', tokenUser, httpHeader)
      .subscribe
      (
        (data) => 
        {
          console.log(data);
          this.SetUserToken(data as Customer);
          return true;
        },
        (error) => 
        {
          console.log("No User Found.");
          return false;
        }
      )
    }
    return false;
  }

  SetUserToken(user: Customer)
  {
    console.log(localStorage.getItem("PetUserSessionToken"));
    localStorage.setItem("PetUserSessionToken", JSON.stringify(user));
    this.router.navigate(['dashboard']);
  }

  GetCurrentUser(): Customer | null
  {
    if(this.ValidUserToken())
    {
      console.log(localStorage.getItem("PetUserSessionToken"));
      //return JSON.parse(localStorage.getItem("PetUserSessionToken")!);
    }
    return null;
  }
}
