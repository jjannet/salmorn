import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CheckoutComponent } from './checkout.component';
import { OrderSummaryModule } from '../order-summary/order-summary.module';

import { CartService } from '../../services/cart.service';

import { CheckoutRouterModule } from './checkout-router';
import { CustomerFormComponent } from './customer-form/customer-form.component';
import { CheckoutSummaryComponent } from './checkout-summary/checkout-summary.component';
import { CheckoutItemComponent } from './checkout-item/checkout-item.component';

@NgModule({
  imports: [
    CommonModule, CheckoutRouterModule, OrderSummaryModule
  ],
  providers: [CartService],
  declarations: [CheckoutComponent, CustomerFormComponent, CheckoutSummaryComponent, CheckoutItemComponent]
})
export class CheckoutModule { }
