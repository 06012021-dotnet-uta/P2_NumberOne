import { Component, OnInit } from '@angular/core';
import { LoginService } from '../login.service';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-pet-navbar',
  templateUrl: './pet-navbar.component.html',
  styleUrls: ['./pet-navbar.component.css']
})
export class PetNavbarComponent implements OnInit {

  constructor(private login: LoginService, private auth: AuthService) { }

  ngOnInit(): void {
  }

  title = 'PetTracker';

  Logout()
  {
    this.login.logout();
  }

  IsLoggedIn()
  {
    return this.auth.ValidUserToken()
  }

}
