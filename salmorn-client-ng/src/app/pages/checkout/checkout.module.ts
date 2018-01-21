import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CheckoutComponent } from './checkout.component';
import { OrderSummaryModule } from '../order-summary/order-summary.module';

import { FormsModule } from '@angular/forms';

import { CartService } from '../../services/cart.service';
import { OrderService } from '../../services/order.service';

import { CheckoutRouterModule } from './checkout-router';
import { CustomerFormComponent } from './customer-form/customer-form.component';
import { CheckoutSummaryComponent } from './checkout-summary/checkout-summary.component';
import { CheckoutItemComponent } from './checkout-item/checkout-item.component';
import { CheckoutResultComponent } from './checkout-result/checkout-result.component';

@NgModule({
  imports: [
    CommonModule, CheckoutRouterModule, OrderSummaryModule, FormsModule
  ],
  providers: [CartService, OrderService],
  declarations: [CheckoutComponent, CustomerFormComponent, CheckoutSummaryComponent, CheckoutItemComponent, CheckoutResultComponent]
})
export class CheckoutModule { }
