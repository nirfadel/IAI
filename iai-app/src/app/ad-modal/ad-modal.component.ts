import { Location } from './../model/Location';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ApiAdService } from '../services/api.ad.service';
import { FormGroup, FormControl } from "@angular/forms";
import { Ad } from '../model/Ad';
import { AdUpdate } from '../model/AdUpdate';

@Component({
  selector: 'app-ad-modal',
  templateUrl: './ad-modal.component.html',
  styleUrl: './ad-modal.component.css'
})
export class AdModalComponent {
 isUpdate!: boolean;
  @Output("getAds") parentAds: EventEmitter<any> = new EventEmitter();

  adForm = new FormGroup({
    title: new FormControl(""),
    content: new FormControl(""),
    location: new FormGroup({
      lat: new FormControl(""),
      lng: new FormControl("")
    }),
    type: new FormControl(0)
  });
  constructor(private apiAdService: ApiAdService){}

  saveAd(){
    const ad = new Ad();
    let formData = this.adForm.value;
    if(formData.title != "")
      ad.title = formData.title!;
    if(formData.content != "")
      ad.content = formData.content!;
    if(formData.location != null && formData.location.lat != "" && formData.location.lng != ""){
      ad.location = new Location();
      ad.location.lat = Number(formData.location.lat);
      ad.location.lng = Number(formData.location.lng);
    }
    if(formData.type != 0)
    {
      ad.adType = Number(formData.type);
    }
    this.apiAdService.addNewAd(ad)
    .subscribe(res=>{
      this.parentAds.emit();
    })
  }

  openForUpdate(adObj: Ad){
    const ad = new Ad();
    
  }

  updateAd(){
    const adUpdate = new AdUpdate();
    let formData = this.adForm.value;
    if(formData.title != "")
      adUpdate.title = formData.title!;
    if(formData.content != "")
      adUpdate.content = formData.content!;
    if(formData.location != null && formData.location.lat != "" && formData.location.lng != ""){
      adUpdate.location = new Location();
      adUpdate.location.lat = Number(formData.location.lat);
      adUpdate.location.lng = Number(formData.location.lng);
    }
   
    this.apiAdService.updateAd(adUpdate)
    .subscribe(res=>{
      this.parentAds.emit();
    })
  }
}
