import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GoodsDetailComponent } from './goods-detail.component';
import { GoodsDetailRouterModule } from './goods-detail-route';

import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    FormsModule,CommonModule, GoodsDetailRouterModule
  ],
  providers: [],
  declarations: [GoodsDetailComponent]
})
export class GoodsDetailModule { }
