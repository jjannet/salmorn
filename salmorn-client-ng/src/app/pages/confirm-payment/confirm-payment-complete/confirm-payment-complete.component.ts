import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-confirm-payment-complete',
  templateUrl: './confirm-payment-complete.component.html',
  styleUrls: ['./confirm-payment-complete.component.css']
})
export class ConfirmPaymentCompleteComponent implements OnInit {
  private sub: any;
  orderCode: string = '';

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    document.getElementById('appHeader').style.display = 'none';

    this.sub = this.route.params.subscribe(params => {
     
      this.orderCode = params['orderCode'];

    });
  }
  ngOnDestroy() {
    document.getElementById('appHeader').style.display = 'block';
  }

}
