import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GoodsDetailComponent } from './goods-detail.component';
import { GoodsDetailRouterModule } from './goods-detail-route';

@NgModule({
  imports: [
    CommonModule, GoodsDetailRouterModule
  ],
  providers: [],
  declarations: [GoodsDetailComponent]
})
export class GoodsDetailModule { }
