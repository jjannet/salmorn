import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { GoodsComponent } from './goods.component'

export const routes: Routes = [
    {
        path: '',
        component: GoodsComponent,
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class GoodsRouterModule { }