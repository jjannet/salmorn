import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GoodsCardComponent } from './goods-card/goods-card.component';
import { GoodsDetailComponent } from './goods-detail/goods-detail.component';
import { GoodsComponent } from './goods.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [GoodsCardComponent, GoodsDetailComponent, GoodsComponent]
})
export class GoodsModule { }
