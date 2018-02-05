import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewsComponent } from './news.component';
import { NewsRouterModule } from './news-router';

@NgModule({
  imports: [
    CommonModule, NewsRouterModule
  ],
  declarations: [NewsComponent]
})
export class NewsModule { }
