import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { NgbModalConfig, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { NgForm, NgModel } from '@angular/forms';
import { ForumserviceService } from '../forumservice.service';
import { Forum } from '../Forum';

@Component({
  selector: 'app-forum-header',
  templateUrl: './forum-header.component.html',
  styleUrls: ['./forum-header.component.css'],
  providers:[NgbModalConfig, NgbModal]
})
export class ForumHeaderComponent implements OnInit {
  
  constructor(private modalService: NgbModal, private forumservice: ForumserviceService) { 
    this.ListofForum = [];
  }

  ListofForum: Forum[];

  closeResult = '';
  @Output() searchEmitter = new EventEmitter<string>();
  searchString = '';

  
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

  searchForum(){
    this.searchEmitter.emit(this.searchString);
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
