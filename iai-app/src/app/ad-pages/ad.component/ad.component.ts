import { ApiAdService } from './../../services/api.ad.service';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Ad } from '../../model/Ad';
import { ApiCommentService } from '../../services/api.comment.service';
import { Comment } from '../../model/Comment';

@Component({
  selector: 'app-ad-component',
  templateUrl: './ad.component.html',
  styleUrl: './ad.component.css',
})
export class AdComponent implements OnInit {
  commentText!: string;

constructor(private apiCommentService: ApiCommentService,
            private apiAdService: ApiAdService 
){

}

  ngOnInit(): void {
    const res = this.adData;
  }
  
  @Input() adData!: Ad;
  @Output("parentCall") parentCall: EventEmitter<any> = new EventEmitter();
  @Output("parentModal") parentModal: EventEmitter<any> = new EventEmitter();

  saveComment(){
    if(this.commentText == "")
       return;
    let comment = new Comment();
    comment.adId = this.adData.id;
    comment.text = this.commentText;
 this.apiCommentService.addNewAdComment(comment)
    .subscribe(res=>{
     this.commentText = '';
    })
  }

  deleteAd(){
    this.apiAdService.deleteAd(this.adData.id)
    .subscribe(res=>{
      this.parentCall.emit();
    })
  }

  openUpdateAdModal(){
      this.parentModal.emit(this.adData);
  }
}
