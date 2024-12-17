import { AdUpdate } from './../model/AdUpdate';
import { AdFilter } from '../model/AdFilter';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, of } from 'rxjs';
import { Ad } from '../model/Ad';

@Injectable({
  providedIn: 'root'
})
export class ApiAdService {
  private apiUrl = 'https://localhost:7294/api/Ad';
  constructor(private http: HttpClient) { }

  getAds(adFilter: AdFilter | undefined): Observable<any> {
    const qs =  this.GetUrl(adFilter);
    const url = (qs != "") ? this.apiUrl + '?' + qs : this.apiUrl;
    return this.http.get<any>(`${url}`)
      .pipe(
        catchError(this.handleError<any>('getAds'))
      );
  }

  addNewAd(ad: Ad): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}`, ad, this.httpOptions)
      .pipe(
        catchError(this.handleError<any>('addNewAd'))
      );
  }

  updateAd(adUpdate: AdUpdate): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}`, adUpdate, this.httpOptions)
    .pipe(
      catchError(this.handleError<any>('updateAd'))
    );
  }

  deleteAd(adId: number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/${adId}`, this.httpOptions)
    .pipe(
      catchError(this.handleError<any>('deleteAd'))
    );
  }

  private GetUrl(adFilter: AdFilter | undefined)
  {
    const params = new URLSearchParams();
    if(adFilter == undefined)
      return "";
    if(adFilter?.text != null && adFilter?.text != "")
    {
      params.set("text", adFilter.text);
    }
    if(adFilter!.location != null && adFilter!.location.lat != null && adFilter!.location.lng != null)
    {
      params.set("lat", adFilter!.location.lat.toString());
      params.set("lng", adFilter!.location.lng.toString());
    }
    return params.toString();
  }

  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    };
  }
}
