import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GoodsComponent } from './goods.component';
import { GoodsRouterModule } from './goods-router';

import { ProductService } from '../../services/product.service';
import { JhttpService } from '../../shared/services/jhttp.service';
import { GoodsItemComponent } from './goods-item/goods-item.component';

@NgModule({
  imports: [
    CommonModule, GoodsRouterModule
  ],
  providers: [ ProductService, JhttpService ],
  declarations: [GoodsComponent, GoodsItemComponent]
})
export class GoodsModule { }
