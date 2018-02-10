import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

import { CartService } from '../../../services/cart.service';
import { Cart } from '../../../models/cart';

@Component({
  selector: 'app-checkout-summary',
  templateUrl: './checkout-summary.component.html',
  styleUrls: ['./checkout-summary.component.css']
})
export class CheckoutSummaryComponent implements OnInit {
  @Input() carts: Array<Cart>;
  @Output() submitForm = new EventEmitter();
  shippingSelector: string;

  constructor(private cartService: CartService) { }

  ngOnInit() {
    this.shippingSelector = this.cartService.getShippingType();
  }

  sumTotalOrderItems(): number {
    let qty = 0;
    this.carts.forEach(function(data, i){
      qty += data.qty;
    });

    return qty;
  }

  calProductPrice(): number {
    let totalPrice = 0;
    this.carts.forEach(function(data, index){
      totalPrice += data.product.price * data.qty;
    });

    return totalPrice;
  }

  calShippingPrice(): number {
    if(this.shippingSelector != 'shipping') return 0;
    
    let totalPrice = 0;
    this.carts.forEach(function(data, index){
      totalPrice += data.product.shippintPriceRate * Math.ceil(data.qty / data.product.qtyShippingPriceCeiling);
    });

    return totalPrice;
  }

  calTotalPrice (): number {
    
    return this.calProductPrice() + this.calShippingPrice();
  }

  submit(event) {
    event.preventDefault();
      this.submitForm.emit();
  }
}
