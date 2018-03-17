import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { MenuRouterComponent } from './menu-router/menu-router.component';
import { MenuRouterItemComponent } from './menu-router/menu-router-item/menu-router-item.component';
import { UserBoxComponent } from './user-box/user-box.component';
import { CartBoxComponent } from './cart-box/cart-box.component';

import { CartService } from '../services/cart.service';
import { CartBoxTopComponent } from './cart-box-top/cart-box-top.component';
import { BottomComponent } from './bottom/bottom.component';

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [RouterModule, CartService],
  exports: [ HeaderComponent, MenuRouterComponent, MenuRouterItemComponent, BottomComponent ],
  declarations: [HeaderComponent, MenuRouterComponent, MenuRouterItemComponent, UserBoxComponent, CartBoxComponent, CartBoxTopComponent, BottomComponent]
})
export class CoreModule { }
