import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ConfirmPaymentComponent } from './confirm-payment.component'

export const routes: Routes = [
    {
        path: '',
        component: ConfirmPaymentComponent,
        pathMatch: 'full'
    },
    {
        path: 'res/:orderCode',
        component: ConfirmPaymentComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class ConfirmPaymentRouter { }