import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map'
import 'rxjs/Rx';
import { Response } from '@angular/http'
import { JhttpService } from '../shared/services/jhttp.service';

import { Order } from '../models/order';
import { CustomerOrderDetail } from '../models/customer-order-detail';

@Injectable()
export class OrderService {

  constructor(private http: JhttpService) { }

  GetCustomerDetail(email: string): Observable<Order> {
    var data = {
      email: email
    };
    return this.http.post(`/api/Order/getLastCustomerDetail`, data).map((res: Response) => res.json() as Order);
  }

  CreateOrder(orders: Array<Order>): Observable<string> {
    return this.http.post(`/api/Order`, orders).map((res: Response) => res.json() as string);
  }

  getOrderByCode(orderCode: string):Observable<Order> {
    return this.http.post(`/api/Order/getOrderByCode`, { orderCode: orderCode }).map((res: Response) => res.json() as Order);
  }

}
 