import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  ngOnInit(): void {
  }
  title = 'iai-app';
  event!: Event;
  test!: string;
  onChange(event: Event) {

    this.event = event;
  }
}
