import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfirmPaymentComponent } from './confirm-payment.component';

import { FormsModule } from '@angular/forms';
import { OrderService } from '../../services/order.service';
import { PaymentService } from '../../services/payment.service';

import { ConfirmPaymentRouter } from './confirm-payment-router';

@NgModule({
  imports: [
    CommonModule, ConfirmPaymentRouter, FormsModule
  ],
  providers: [OrderService, PaymentService],
  declarations: [ConfirmPaymentComponent]
})
export class ConfirmPaymentModule { }
