import { Component, OnInit } from '@angular/core';
import { Customer } from '../customer/customer';
import { LoginService } from '../login.service';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  model = new Customer(
    "User Name",
    "",
    0,
    "First Name",
    "Last Name",
    "example@mail.com",
    0.0,
    0.0,
    0,
    8008888888,
    12345);

  submitted = false;
  onSubmit()
  {
    this.submitted = true;

  }

}
