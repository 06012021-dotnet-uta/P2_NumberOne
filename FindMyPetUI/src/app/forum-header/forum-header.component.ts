import { Component, OnInit, Input, Output } from '@angular/core';
import { NgbModalConfig, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { NgForm } from '@angular/forms';
import { ForumserviceService } from '../forumservice.service';
import { Forum } from '../Forum';


@Component({
  selector: 'app-forum-header',
  templateUrl: './forum-header.component.html',
  styleUrls: ['./forum-header.component.css'],
  providers:[NgbModalConfig, NgbModal]
})
export class ForumHeaderComponent implements OnInit {

  forums?: Forum[];

  constructor(private modalService: NgbModal, private forumservice: ForumserviceService) { 
  }

  closeResult = '';
  
  ngOnInit(): void {
  }

  // Events go here
  addForum(forumdata: NgForm): void{
    this.forumservice.AddForum(forumdata.value).subscribe(
      (resp) => {console.log(resp);
        forumdata.reset();
      },
      (err) => {console.log(err);}
    );
  }

  // addForum(forumdata: Forum): void{
  //   this.forumservice.AddForum(forumdata).subscribe(
  //     x => this.forums?.push(x),
  //     y => console.log('there was a problem adding the player')
  //   );
  // }

  searchForum(){
    console.log('Search');
  }


  // Modal functions
  open(content: any) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }

}
