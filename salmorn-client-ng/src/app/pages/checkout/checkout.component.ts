import { Component, OnInit } from '@angular/core';

import { Cart } from '../../models/cart';
import { CartService } from '../../services/cart.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {
  carts: Array<Cart>;
  constructor(private cartService: CartService) { }

  ngOnInit() {
    document.getElementById('appHeader').style.display = 'none';

    this.carts = this.cartService.getAll();
  }

  ngOnDestroy() {
    document.getElementById('appHeader').style.display = 'block';
  }

}
