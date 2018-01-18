import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { MenuRouterComponent } from './menu-router/menu-router.component';
import { MenuRouterItemComponent } from './menu-router/menu-router-item/menu-router-item.component';

@NgModule({
  imports: [
    CommonModule
  ],
  exports: [ HeaderComponent, MenuRouterComponent, MenuRouterItemComponent ],
  declarations: [HeaderComponent, MenuRouterComponent, MenuRouterItemComponent]
})
export class CoreModule { }
