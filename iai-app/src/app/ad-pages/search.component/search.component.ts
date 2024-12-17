import { Component, EventEmitter, Output } from '@angular/core';
import { AdFilter } from '../../model/AdFilter';
import { SharedService } from '../../services/shared.service';
import { Location } from '../../model/Location';

@Component({
  selector: 'app-search-component',
  templateUrl: './search.component.html',
  styleUrl: './search.component.css'
})
export class SearchComponent {
  @Output() dataEmitter = new EventEmitter<any>();
  @Output() eventChange = new EventEmitter<Event>();
  searchText!: string;

  constructor(private sharedService: SharedService){}

  sendData(event: Event) {
    let filter: AdFilter = new AdFilter();
    filter.text = this.searchText;
    filter.location = new Location();
    this.sharedService.emitSiblingEvent(filter);
  }
}
