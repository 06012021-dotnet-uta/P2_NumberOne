import { Component, OnInit } from '@angular/core';
import { NGXLogger } from "ngx-logger";
import { LoginRequest } from "./loginRequest";
import { LoginService } from "../login.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor() 
  {
    //this.logger.debug("LoginComponent Initialized.");
  }

  ngOnInit(): void {
  }

}
