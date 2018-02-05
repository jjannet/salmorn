import { Component, OnInit, Input } from '@angular/core';

import { CustomerOrderDetail } from '../../../models/customer-order-detail';
import { retry } from 'rxjs/operators/retry';

import { OrderService } from '../../../services/order.service';

@Component({
  selector: 'app-customer-form',
  templateUrl: './customer-form.component.html',
  styleUrls: ['./customer-form.component.css']
})
export class CustomerFormComponent implements OnInit {
  @Input() customer: CustomerOrderDetail;
  constructor(private orderService: OrderService) { }

  ngOnInit() {
  }

  findCustomerDetail() {
    this.orderService.GetCustomerDetail(this.customer.email).subscribe(res => {
      this.customer.address = res.address;
      this.customer.firstName = res.firstName;
      this.customer.lastName = res.lastName;
      this.customer.province = res.province;
      this.customer.tel = res.tel;
      this.customer.zipCode = res.zipCode;
    });
  }

}
