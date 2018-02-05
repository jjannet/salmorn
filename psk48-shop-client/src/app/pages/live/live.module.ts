import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LiveComponent } from './live.component';
import { LiveRouterModule } from './live-router';

@NgModule({
  imports: [
    CommonModule, LiveRouterModule
  ],
  declarations: [LiveComponent]
})
export class LiveModule { }
