import { Pipe, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Globals } from './globals';
import { Customer } from './customer/customer';
import { Router } from '@angular/router';
import { AuthService } from './auth.service';


@Injectable({
  providedIn: 'root'
})
export class LoginService 
{

  constructor(private http: HttpClient, private global: Globals, private router: Router, private auth: AuthService) { }

  httpHeader = 
  {
    headers: new HttpHeaders
    ({
      'Content-Type': 'application/json'
    })
  }

  private loginUrl = 'api/Customer/Login';

  loginRequest(Info: UserInfo) 
  {
    if (localStorage.getItem("PetUserSessionToken") === null) 
    {
      console.log("Data: ", Info);
      this.http.post(this.global.currentHostURL()+this.loginUrl, Info, this.httpHeader)
      .subscribe
      (
        (data) => 
        {
          console.log(data);
          this.auth.SetUserToken(data as Customer);
          return data as Customer;
        },
        (error) => 
        {
          console.log(error)
          return new Customer();
        }
      );
    }
    else
    {
      this.router.navigate(['']);
    }
  }
  logout(): boolean
  {
    if (localStorage.getItem("PetUserSessionToken") === null) 
    {
      return false;
    }
    else
    {
      localStorage.removeItem("PetUserSessionToken");
      this.router.navigate(['']);
      return true;
    }
  }
}

export class UserInfo
{
  constructor(
    public username: string = '',
    public password: string = ''
  ) {}
}