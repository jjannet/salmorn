import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfirmPaymentComponent } from './confirm-payment.component';

import { ConfirmPaymentRouter } from './confirm-payment-router';

@NgModule({
  imports: [
    CommonModule, ConfirmPaymentRouter
  ],
  declarations: [ConfirmPaymentComponent]
})
export class ConfirmPaymentModule { }
