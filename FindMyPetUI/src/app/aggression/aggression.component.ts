import { Component, OnInit } from '@angular/core';
import { AggressionInteface, RegisterPetService } from '../register-pet.service';


@Component({
  selector: 'app-aggression',
  templateUrl: './aggression.component.html',
  styleUrls: ['./aggression.component.css']
})
export class AggressionComponent implements OnInit {

  constructor(private AggressionListService: RegisterPetService) { 
    this.ListofAggression = [];

  }

  ListofAggression: AggressionInteface[];

  ngOnInit(): void {
    this.AggressionListService.GetAggressionList().subscribe
    (
      ListofAggression => this.ListofAggression = ListofAggression
    )
  }

  onSubmit()
  {
    //this.ListofBreeds = this.breedListService.GetBreedList();

  }   

}
