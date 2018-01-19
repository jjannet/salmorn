import { Injectable } from '@angular/core';
import { Cart } from '../models/cart';
import { Product } from '../models/product';

@Injectable()
export class CartService {
  cartKey: string = 'salmorn-cart';


  constructor() { }

  getAll(): Array<Cart> {
    var js = localStorage.getItem(this.cartKey);
    if (js && js != '') {
      return JSON.parse(js) as Array<Cart>;
    } else {
      return [];
    }
  }

  setCart(carts: Array<Cart>){
    localStorage.setItem(this.cartKey, JSON.stringify(carts));
  }

  addProduct(product: Product, qty: number) {
    var carts = this.getAll();
    carts.push({ product: product, qty: qty });
    this.setCart(carts);
  }

  updateProduct(product: Product, qty: number) {
    var carts = this.getAll();
    for(let i = 0 ; i < carts.length; i++){
      if(carts[i].product.id === product.id){
        carts[i].qty = qty;
      }
    }
    this.setCart(carts);
  }

  removeProduct(product:Product){
    var carts = this.getAll();
    var index = carts.findIndex(m=>m.product.id === product.id);
    carts = carts.splice(index, 1);
  }

}
