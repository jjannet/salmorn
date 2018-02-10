import { Component, OnInit } from '@angular/core';

import { Cart } from '../../models/cart';
import { CustomerOrderDetail } from '../../models/customer-order-detail';
import { CartService } from '../../services/cart.service';
import { OrderService } from '../../services/order.service';
import { Order } from '../../models/order';

import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {
  carts: Array<Cart>;
  customer: CustomerOrderDetail;
  constructor(private cartService: CartService, private orderService: OrderService, private route: Router) { }

  ngOnInit() {
    this.initCustomerBlankData();
    this.carts = this.cartService.getAll();
  }

  ngOnDestroy() {
  }

  initCustomerBlankData() {
    this.customer = {
      address: '', email: '', firstName: '', lastName: '', province: '', tel: '', zipCode: ''
    };
  }

  submitForm(event) {
    if (this.validateSubmit()) {
      this.loading(true);
      var orders = this.buildOrderModel();
      this.orderService.CreateOrder(orders).subscribe(res => {
        if (res != null) {

          this.cartService.clearCart();
          this.cartService.clearShippingType();

          this.route.navigate([`checkout/result/${res}/${orders[0].firstName}`]);


        } else {
          alert('การยืนยัน order ล้มเหลว กรุณาติดต่อ email: jirawat.jannet@gmail.com');
        }


        this.loading(false);
      });
    } else {
      alert('กรุณากรอกข้อมูลให้ครบถ้วน');
    }
  }
  validateSubmit() {
    let isValid: boolean = true;

    if (!this.customer.address || !this.validateEmail(this.customer.email)) isValid = false;
    if (!this.customer.email) isValid = false;
    if (!this.customer.firstName) isValid = false;
    if (!this.customer.lastName) isValid = false;
    if (!this.customer.province) isValid = false;
    if (!this.customer.tel) isValid = false;
    if (!this.customer.zipCode) isValid = false;

    return isValid;
  }

  validateEmail(email: string) {
    let EMAIL_REGEXP = /^[a-z0-9!#$%&'*+\/=?^_`{|}~.-]+@[a-z0-9]([a-z0-9-]*[a-z0-9])?(\.[a-z0-9]([a-z0-9-]*[a-z0-9])?)*$/i;
    return EMAIL_REGEXP.test(email);
  }

  buildOrderModel(): Array<Order> {
    let orders: Array<Order> = [];
    let carts = this.cartService.getAll();
    let c = this.customer;
    let shippingType = this.cartService.getShippingType();

    carts.forEach(function (data, i) {
      var isMeetReceive = shippingType == 'manual';
      var isShipping = shippingType == 'shipping';
      
      orders.push({
        address: c.address,
        code: '',
        email: c.email,
        firstName: c.firstName,
        isMeetReceive: isMeetReceive,
        isShipping: isShipping,
        lastName: c.lastName,
        product: data.product,
        productId: data.product.id,
        province: c.province,
        qty: data.qty,
        tel: c.tel,
        zipCode: c.zipCode,
        isActive: true,
        payment: null
      });
    });

    return orders;
  }

  loading(isLoading: boolean) {
    if (isLoading)
      document.getElementById('loading').style.display = 'block';
    else
      document.getElementById('loading').style.display = 'none';
  }
}
