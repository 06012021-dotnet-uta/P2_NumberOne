import { Output } from '@angular/core';
import { Component, OnInit, EventEmitter } from '@angular/core';
import { NgForm } from '@angular/forms';
import { RegisterCustomer } from '../register-customer';
import { SignupService  } from '../signup.service';



@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})


export class SignUpComponent implements OnInit {

//=====================How to insert any record in the DB=====================
//Inject the service in the constructore
  constructor(private signupservice: SignupService) { }
//Creating a method Register and the [--> registerform <--]contains all of the data comes from the form og type 
//NgForm imported  import [ --{ NgForm } from '@angular/forms'--]
  register(registerform: NgForm){
      this.signupservice.addCustomer(registerform.value).subscribe(
        (resp) => {
           console.log(resp);//this line to give the respons in the console 
           registerform.reset();
        },      
        (err)=>{
          console.log(err);//this line to give the respons in the console if anything wrong happend 
        }
      );
  }

  ngOnInit(): void {}
  
}
