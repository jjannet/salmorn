import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { MenuRouterComponent } from './menu-router/menu-router.component';
import { MenuRouterItemComponent } from './menu-router/menu-router-item/menu-router-item.component';
import { UserBoxComponent } from './user-box/user-box.component';
import { CartBoxComponent } from './cart-box/cart-box.component';

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [RouterModule],
  exports: [ HeaderComponent, MenuRouterComponent, MenuRouterItemComponent ],
  declarations: [HeaderComponent, MenuRouterComponent, MenuRouterItemComponent, UserBoxComponent, CartBoxComponent]
})
export class CoreModule { }
