import { Component, OnInit } from '@angular/core';
import { LoginService } from '../login.service';
import { Customer } from './customer';
import { AuthService } from '../auth.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { Observable, of } from 'rxjs';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  constructor(private login: LoginService, private auth: AuthService) {
    this.user = new Customer();
   }

  user: Customer;

  ngOnInit(): void {
  }

  GetUserInfo()
  {
    this.auth.GetUserInfo()
    .subscribe
    (
      CurrentUser => this.user = CurrentUser
    )
  }
}
