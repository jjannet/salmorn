import { Component, OnInit } from '@angular/core';
import { Router, RouterModule } from '@angular/router';

import { CartService } from '../../services/cart.service';

@Component({
  selector: 'app-cart-box-top',
  templateUrl: './cart-box-top.component.html',
  styleUrls: ['./cart-box-top.component.css']
})
export class CartBoxTopComponent implements OnInit {

  constructor(private route:Router, private cartService: CartService) { }

  ngOnInit() {
  }


  getProductTotal(): number {
    let carts = this.cartService.getAll();
    if(carts.length > 0){
      return carts.map(m=>m.qty).reduce((sum, current) => sum + current);
    }else{
      return 0;
    }
  }

  gotoSummary(){
    this.route.navigate(['summary']);
  }
}
