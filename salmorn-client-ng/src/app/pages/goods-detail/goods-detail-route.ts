import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { GoodsDetailComponent } from './goods-detail.component'

export const routes: Routes = [
    {
        path: '',
        component: GoodsDetailComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class GoodsDetailRouterModule { }