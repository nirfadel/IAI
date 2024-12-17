import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  constructor() { }

  private siblingEvent = new Subject<any>();

  siblingEvent$ = this.siblingEvent.asObservable();

  emitSiblingEvent(data: any) {
    this.siblingEvent.next(data);
}
}
