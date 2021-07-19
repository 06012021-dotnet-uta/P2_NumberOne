import { Component, OnInit } from '@angular/core';
import { LoginService, UserInfo } from '../login.service';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {

  constructor(private loginService: LoginService) 
  { 
    this.model = new UserInfo();
  }

  ngOnInit(): void {
  }

  submitted = false;
  
  model: UserInfo;

  onSubmit()
  {
    this.submitted = true;
    this.loginService.loginRequest(this.model);
    console.log("LoginRequested");
}
}
