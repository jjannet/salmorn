import { Component, OnInit } from '@angular/core';
import { Router, RouterModule } from '@angular/router';

import { CartService } from '../../services/cart.service';

import { Cart } from '../../models/cart';
import { Product } from '../../models/product';

@Component({
  selector: 'app-order-summary',
  templateUrl: './order-summary.component.html',
  styleUrls: ['./order-summary.component.css']
})
export class OrderSummaryComponent implements OnInit {
  carts: Array<Cart>;
  shippingSelector: string = 'shipping';
  constructor(private cartService: CartService, private route:Router) { }

  ngOnInit() {
    //this.initialDefaultDatas();
    this.carts = this.cartService.getAll();
    document.getElementById('appHeader').style.display = 'none';
  }

  ngOnDestroy() {
    document.getElementById('appHeader').style.display = 'block';
  }

  qtyChanged(cart: Cart){
    let index = this.carts.findIndex(m=>m.product.id === cart.product.id);
    this.carts[index].qty = cart.qty;
  }

  removeProduct(cart: Cart){
    this.cartService.removeProduct(cart);
    this.carts = this.cartService.getAll();
  }

  shippingTypeChange( type: string) {
    this.shippingSelector = type;
    this.cartService.setShippingType(this.shippingSelector);
  }

  confirmOrder () {
    this.cartService.setCart(this.carts);
    this.cartService.setShippingType(this.shippingSelector);
    this.route.navigate(['checkout']);
  }

  // for test
  initialDefaultDatas() {
    this.carts = [
      {
        qty: 10, product: {
          name: 'Photoset Christmas', title: 'Pre-Order BNK48 Merry Christmas 2017 Photoset (5 Random Photo Per Set)', code: '', cost: 0, createBy: 1, createDate: new Date(), detail: '', id: 1, isActive: true, isDelete: false, isManualPickup: true, isPreOrder: true, isUseStock: false, note: '', pickupAt: 'ตู้ปลา', preEnd: new Date(), preStart: new Date(), price: 250, qtyShippingPriceCeiling: 10, shippintPriceRate: 100, stockQrty: 0, unitName: 'ชุด', updateBy: 1, updateDate: new Date(), weight: 100
          , images: [{ fileName: 'https://kadnud.s3-ap-southeast-1.amazonaws.com/bnk48/product_media/od-merry-christmas-2017-photoset/1972afe7-8d6b-45b0-ba66-fb726c69118b.png', id: 1, ipAddress: '', macAddress: '', type: '', uploadDate: new Date(), userId: 1 }]
        }
      }
      , {
        qty: 20, product: {
          name: 'Photoset Koisuru Fortune Cookie', title: 'Pre-Order BNK48 Koisuru Fortune Cookie Senbatsu Photoset (5 Random Photo Per Set)', code: '', cost: 0, createBy: 1, createDate: new Date(), detail: '', id: 1, isActive: true, isDelete: false, isManualPickup: true, isPreOrder: true, isUseStock: false, note: '', pickupAt: 'ตู้ปลา', preEnd: new Date(), preStart: new Date(), price: 250, qtyShippingPriceCeiling: 10, shippintPriceRate: 100, stockQrty: 0, unitName: 'ชุด', updateBy: 1, updateDate: new Date(), weight: 100
          , images: [{ fileName: 'https://kadnud.s3-ap-southeast-1.amazonaws.com/bnk48/product_media/od-KFC-photoset/01a7b57e-e650-4d8c-bfa7-a17ed15b8f84.png', id: 1, ipAddress: '', macAddress: '', type: '', uploadDate: new Date(), userId: 1 }]
        }
      }
    ];
  }
}
