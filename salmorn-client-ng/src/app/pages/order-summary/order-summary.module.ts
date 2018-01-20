import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderSummaryComponent } from './order-summary.component';

import { FormsModule } from '@angular/forms';

import { CartService } from '../../services/cart.service';

import { OrderSummaryRouterModule } from './order-summary-router';
import { OrderItemComponent } from './order-item/order-item.component';
import { OrderShippingComponent } from './order-shipping/order-shipping.component';
import { OrderPriceComponent } from './order-price/order-price.component';

@NgModule({
  imports: [
    CommonModule
    , OrderSummaryRouterModule
    , FormsModule
  ],
  providers: [CartService],
  declarations: [OrderSummaryComponent, OrderItemComponent, OrderShippingComponent, OrderPriceComponent],
  exports: [OrderItemComponent]
})
export class OrderSummaryModule { }
