import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderSummaryComponent } from './order-summary.component';

import { FormsModule } from '@angular/forms';

import { OrderSummaryRouterModule } from './order-summary-router';
import { OrderItemComponent } from './order-item/order-item.component';
import { OrderShippingComponent } from './order-shipping/order-shipping.component';

@NgModule({
  imports: [
    CommonModule
    , OrderSummaryRouterModule
    , FormsModule
  ],
  declarations: [OrderSummaryComponent, OrderItemComponent, OrderShippingComponent]
})
export class OrderSummaryModule { }
