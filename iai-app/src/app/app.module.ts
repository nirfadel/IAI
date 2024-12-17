import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AdsComponent } from './ad-pages/ads.component/ads.component';
import { AdComponent } from './ad-pages/ad.component/ad.component';
import { SearchComponent } from './ad-pages/search.component/search.component';
import { ApiAdService } from './services/api.ad.service';
import { ApiCommentService } from './services/api.comment.service';
import { HttpClient, HttpClientModule, HttpHandler } from '@angular/common/http';
import { AdModalComponent } from './ad-modal/ad-modal.component';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";

@NgModule({
  declarations: [
    AdsComponent,
    AdComponent,
    SearchComponent,
    AppComponent,
    AdModalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule 
  ],
  providers: [
    ApiAdService,
    ApiCommentService,
    HttpClient,
    HttpClientModule],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ],
  bootstrap: [AppComponent]
})
export class AppModule { }
