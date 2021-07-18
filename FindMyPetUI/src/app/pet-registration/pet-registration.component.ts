import { Output } from '@angular/core';
import { Component, OnInit, EventEmitter } from '@angular/core';
import { NgForm } from '@angular/forms';
import { GenderService } from '../gender.service';
import { RegisterPetService,   CategoryInteface , AggressionInteface, GenderInteface } from '../register-pet.service';

@Component({
  selector: 'app-pet-registration',
  templateUrl: './pet-registration.component.html',
  styleUrls: ['./pet-registration.component.css']
})
export class PetRegistrationComponent implements OnInit {

//=====================How to insert any record in the DB=====================
//Inject the service in the constructore
  constructor(private  petservice: RegisterPetService) {
    this.ListofGender = [];
    this.ListofCategory = [];
    this.ListofAggression = [];

   }
//Creating a method Register and the [--> registerform <--]contains all of the data comes from the form og type 
//NgForm imported  import [ --{ NgForm } from '@angular/forms'--]
  register(registerpetform: NgForm){
    //console.log(registerpetform.value);
      this.petservice.addPet(registerpetform.value)
      .subscribe
      (
        (resp) => {
          console.log(resp);//this line to give the respons in the console 
          registerpetform.reset();
        },      
        (err)=>{
          console.log(err);//this line to give the respons in the console if anything wrong happend 
        }
      );
  }



  ListofAggression: AggressionInteface[];
  ListofCategory: CategoryInteface[];
  ListofGender: GenderInteface[];
  ngOnInit(): void {
    //this.ListofBreeds = this.breedListService.GetBreedList();
   
    

   
    this.petservice.GetGenderList().subscribe
    (
      ListofGender => this.ListofGender = ListofGender
    )
    
    
    this.petservice.GetAggressionList().subscribe
    (
      ListofAggression => this.ListofAggression = ListofAggression
    )

    this.petservice.GetCategoryList().subscribe
    (
      ListofCategory => this.ListofCategory = ListofCategory
    )

  }
}
