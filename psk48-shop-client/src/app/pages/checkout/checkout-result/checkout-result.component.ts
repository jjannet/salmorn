import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-checkout-result',
  templateUrl: './checkout-result.component.html',
  styleUrls: ['./checkout-result.component.css']
})
export class CheckoutResultComponent implements OnInit {
  private sub: any;
  orderCode: string;
  firstName: string;
  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.orderCode = params['orderCode'];
      this.firstName = params['firstName'];

      console.log(this.orderCode, this.firstName);
    });
  }

  ngOnDestroy() {
  }

}
