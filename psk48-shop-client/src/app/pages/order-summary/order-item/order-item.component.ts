import { Component, OnInit, Input, Output, EventEmitter  } from '@angular/core';

import { Cart } from '../../../models/cart';
import { Product } from '../../../models/product';

@Component({
  selector: 'app-order-item',
  templateUrl: './order-item.component.html',
  styleUrls: ['./order-item.component.css']
})
export class OrderItemComponent implements OnInit {
  @Input() cart: Cart;
  @Output() qtyChanged = new EventEmitter();
  @Output() removeProduct = new EventEmitter();
  constructor() { }

  ngOnInit() {
  }

  getImagePath(product: Product) : string {
    if(product.images.length > 0) {
      return product.images[0].fileName;
    }else return '../contents/images/no-image.jpg';
  }

  errorHandler(event) {
    event.target.src = "../contents/images/no-image.jpg";
  }

  qtyChange (event) {
    event.preventDefault();
    this.qtyChanged.emit(this.cart);
  }

  deleteItem(cart: Cart){
    if(confirm('คุณต้องการลบการสั่งซื้อสินค้า ' + cart.product.name + ' ใช่หรือไม่ ?')){
      event.preventDefault();
      this.removeProduct.emit(this.cart);
    }
  }

}
