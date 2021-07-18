import { Output } from '@angular/core';
import { Component, OnInit, EventEmitter } from '@angular/core';
import { NgForm } from '@angular/forms';
import { RegisterCustomer } from '../register-customer';
import { SignupService  } from '../signup.service';
import { Router } from '@angular/router';



@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})


export class SignUpComponent implements OnInit {

//=====================How to insert any record in the DB=====================
//Inject the service in the constructore
  constructor(private signupservice: SignupService, private router: Router) { }
//Creating a method Register and the [--> registerform <--]contains all of the data comes from the form og type 
//NgForm imported  import [ --{ NgForm } from '@angular/forms'--]
  register(registerform: NgForm){
      this.signupservice.addCustomer(registerform.value).subscribe(
        (resp) => {
           console.log(resp);//this line to give the respons in the console 
           registerform.reset();
           this.router.navigate(['login']);
        },      
        (err)=>{
          console.log(err);//this line to give the respons in the console if anything wrong happend 
        }
      );
  }

  ngOnInit(): void {}
  
}
