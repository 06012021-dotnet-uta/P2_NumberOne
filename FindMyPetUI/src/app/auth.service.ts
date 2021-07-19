import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Globals } from './globals';
import { Customer } from './customer/customer';
import { Observable, of} from 'rxjs';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';


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
    if(localStorage.getItem("PetUserSessionToken") === null || localStorage.getItem("PetUserSessionToken") === undefined)
    {
      return false;
    }
    else
    {
      //this.user = this.GetCurrentUser()!;
      // this.loginInfo = {username: this.user.username, password: this.user.password};
      // this.sessionUser = this.login.loginRequest(this.loginInfo)!;
      // if(this.sessionUser == this.user)
      // {
      //   return true;
      // }
      // else
      // {
      //   return false;
      // }
      return true;
    }
  }

  SetUserToken(user: Customer)
  {
    //console.log(user);
    localStorage.setItem("PetUserSessionToken", JSON.stringify(user));
    this.router.navigate(['dashboard']);
  }

  GetCurrentUser(): Customer | null
  {
    if(this.ValidUserToken())
    {
      console.log("Token: ",localStorage.getItem("PetUserSessionToken"));
      return JSON.parse(localStorage.getItem("PetUserSessionToken")!);
    }
    return null;
  }

  GetUserInfo(): Observable<Customer> {
    if(this.ValidUserToken() == false)
    {
      this.router.navigate(["login"]);
    }
    console.log(localStorage.getItem("PetUserSessionToken"));
    let user = JSON.parse("Token:" + localStorage.getItem("PetUserSessionToken")!);
    let url = this.global.currentHostURL()+'api/Customer/Details/'+user.customerId;
    console.log(url);
    return this.http.get<Customer>(url);
  } 
}
