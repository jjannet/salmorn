import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

import { Cart } from '../../../models/cart';
import { retry } from 'rxjs/operators/retry';

import { CartService } from '../../../services/cart.service';

@Component({
  selector: 'app-order-shipping',
  templateUrl: './order-shipping.component.html',
  styleUrls: ['./order-shipping.component.css']
})
export class OrderShippingComponent implements OnInit {
  @Input() carts: Array<Cart>;
  @Output() shippingTypeChange = new EventEmitter();
  shippingType: string = 'shipping';
  constructor(private cartService: CartService) { }

  ngOnInit() {
    this.shippingType = this.cartService.getShippingType();
  }

  changeShippingType(type: string) {
    this.shippingType = type;
    this.shippingTypeChange.emit(type);
  }

  calculateShippingPrice(cart: Cart): number {
    return cart.product.shippintPriceRate * Math.ceil(cart.qty / cart.product.qtyShippingPriceCeiling);;
  }

  calculateProductPrice(cart: Cart): number {
    return cart.qty * cart.product.price;
  }
}
