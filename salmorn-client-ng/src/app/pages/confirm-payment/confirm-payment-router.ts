import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ConfirmPaymentComponent } from './confirm-payment.component'
import { ConfirmPaymentCompleteComponent } from './confirm-payment-complete/confirm-payment-complete.component'

export const routes: Routes = [
    {
        path: '',
        component: ConfirmPaymentComponent,
        pathMatch: 'full'
    },
    {
        path: 'res/:orderCode',
        component: ConfirmPaymentComponent
    },
    {
        path: 'complete/:orderCode',
        component: ConfirmPaymentCompleteComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class ConfirmPaymentRouter { }