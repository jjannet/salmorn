import { Injectable } from '@angular/core';
import { Cart } from '../models/cart';
import { Product } from '../models/product';
import { retry } from 'rxjs/operator/retry';

@Injectable()
export class CartService {
  private cartKey: string = 'salmorn-cart';
  private shippingTypeKey: string = 'salmorn-shipping';


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

  clearCart() {
    localStorage.removeItem(this.cartKey);
  }

  addProduct(product: Product, qty: number) {
    var carts = this.getAll();

    if(carts.filter(m=>m.product.id === product.id).length > 0) {
      let index = carts.findIndex(m=>m.product.id === product.id);
      carts[index].qty += qty;
    } else{
      carts.push({ product: product, qty: qty });
    }
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

  removeProduct(cart:Cart){
    var carts = this.getAll();
    carts = carts.filter(m=>m.product.id != cart.product.id);
    this.setCart(carts);
  }


  setShippingType(type: string) {
    localStorage.setItem(this.shippingTypeKey, type);
  }
  getShippingType() : string{
    var sht = localStorage.getItem(this.shippingTypeKey);
    if(sht) return sht;
    else return 'shipping';
  }
  
  clearShippingType() {
    localStorage.removeItem(this.shippingTypeKey);
  }

}
