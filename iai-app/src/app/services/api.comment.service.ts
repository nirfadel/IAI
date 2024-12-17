import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, of } from 'rxjs';
import { Comment } from '../model/Comment';

@Injectable({
  providedIn: 'root'
})
export class ApiCommentService {
  private apiUrl = 'https://localhost:7294/api/AdComment';
  constructor(private http: HttpClient) { }

  getComments(adId: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${adId}`)
      .pipe(
        catchError(this.handleError<any>('getComments'))
      );
  }

  addNewAdComment(comment: Comment): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}`, comment, this.httpOptions)
      .pipe(
        catchError(this.handleError<any>('addNewAdComment'))
      );
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
