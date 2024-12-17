import { ApiAdService } from './../../services/api.ad.service';
import { Component, ElementRef, Input, input, OnInit, ViewChild } from '@angular/core';
import { AdFilter } from '../../model/AdFilter';
import { Ad } from '../../model/Ad';
import { SharedService } from '../../services/shared.service';

declare var bootstrap: any;

@Component({
  selector: 'app-ads-component',
  templateUrl: './ads.component.html',
  styleUrl: './ads.component.css',
 
})
export class AdsComponent implements OnInit {
  constructor(private apiAdService: ApiAdService,
    private sharedService: SharedService
  ){}
  ngOnInit(): void {
    this.sharedService.siblingEvent$.subscribe(message => {
      this.receivedData = message;
      this.getAds();
    });
    this.getAds();
  }
  @Input() receivedData: AdFilter | undefined;
  @Input()
  set filter(event: any) {
    if (event) {
      this.getAds();
    }
  }

  ads: Ad[] | undefined

  getAds(){
    this.apiAdService.getAds(this.receivedData)
    .subscribe(res=>{
      this.ads = res;
      this.closeAdModal();
    })
  }

  openAdModal(){
    const adModal = new bootstrap.Modal(document.getElementById("adModal"));
    adModal.show();

  }

   closeAdModal(){
    const adModal = new bootstrap.Modal(document.getElementById("adModal"));
    adModal.hide();
  } 

  parentCall(){
    this.getAds();

  }

  parentModal(ad: Ad)
  {
    //getting modal data and send ad to modal component
    //disabled and change 
    this.openAdModal();
  }

}
