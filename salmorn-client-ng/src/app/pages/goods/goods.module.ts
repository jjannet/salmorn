import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GoodsComponent } from './goods.component';
import { GoodsRouterModule } from './goods-router';

@NgModule({
  imports: [
    CommonModule, GoodsRouterModule
  ],
  declarations: [GoodsComponent]
})
export class GoodsModule { }
