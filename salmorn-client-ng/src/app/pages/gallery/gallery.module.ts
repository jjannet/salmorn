import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GalleryComponent } from './gallery.component';
import { GalleryRouterModule } from './gallery-router';

@NgModule({
  imports: [
    CommonModule, GalleryRouterModule
  ],
  declarations: [GalleryComponent]
})
export class GalleryModule { }
