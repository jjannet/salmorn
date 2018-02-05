import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CartDetailComponent } from './cart-detail.component';
import { CartDetailRouterModule } from './cart-detail-router';

@NgModule({
  imports: [
    CommonModule, CartDetailRouterModule
  ],
  declarations: [CartDetailComponent]
})
export class CartDetailModule { }
