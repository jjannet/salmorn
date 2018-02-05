import { Component, OnInit, Input } from '@angular/core';

import { Cart } from '../../../models/cart';

@Component({
  selector: 'app-order-price',
  templateUrl: './order-price.component.html',
  styleUrls: ['./order-price.component.css']
})
export class OrderPriceComponent implements OnInit {
  @Input() carts: Array<Cart>;
  @Input() shippingSelector: string;
  constructor() { }

  ngOnInit() {
  }

  calTotalPrice (): number {
    let totalPrice = 0;
    let spt = this.shippingSelector;
    this.carts.forEach(function (data){
      totalPrice += data.product.price * data.qty;
       if(spt == 'shipping') {
         totalPrice += data.product.shippintPriceRate * Math.ceil(data.qty / data.product.qtyShippingPriceCeiling);
       }
    });
 
    return totalPrice;
  }
}
