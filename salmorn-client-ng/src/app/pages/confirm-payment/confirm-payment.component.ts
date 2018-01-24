import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-confirm-payment',
  templateUrl: './confirm-payment.component.html',
  styleUrls: ['./confirm-payment.component.css']
})
export class ConfirmPaymentComponent implements OnInit {

  constructor() { }

  hours: Array<number> = [];
  minutes: Array<number> = [];

  ngOnInit() {
    document.getElementById('appHeader').style.display = 'none';
    for(let i = 0; i < 24; i++){
      this.hours.push(i);
    }
    for(let i = 0; i < 60; i++){
      this.minutes.push(i);
    }
  }

  ngOnDestroy() {
    document.getElementById('appHeader').style.display = 'block';
  }

}
