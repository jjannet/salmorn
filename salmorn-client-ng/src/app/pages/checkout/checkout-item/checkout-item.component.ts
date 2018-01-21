import { Component, OnInit, Input } from '@angular/core';

import { CartService } from '../../../services/cart.service';
import { Cart } from '../../../models/cart';

@Component({
  selector: 'app-checkout-item',
  templateUrl: './checkout-item.component.html',
  styleUrls: ['./checkout-item.component.css']
})
export class CheckoutItemComponent implements OnInit {
  @Input() carts: Array<Cart>;
  constructor(private cartService: CartService) { }

  ngOnInit() {
  }


  qtyChanged(cart: Cart){
    let index = this.carts.findIndex(m=>m.product.id === cart.product.id);
    this.carts[index].qty = cart.qty;
    this.cartService.setCart(this.carts);
  }

  removeProduct(cart: Cart){
    this.cartService.removeProduct(cart);
    this.carts = this.cartService.getAll();
  }

}
