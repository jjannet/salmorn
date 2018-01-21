import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CheckoutComponent } from './checkout.component'
import { CheckoutResultComponent } from './checkout-result/checkout-result.component'

export const routes: Routes = [
    {
        path: '',
        component: CheckoutComponent
    },
    {
        path: 'result/:orderCode/:firstName',
        component: CheckoutResultComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class CheckoutRouterModule { }