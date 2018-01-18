import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CoreModule } from './core/core.module';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { AppRoutungModule } from './app-router';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule, CoreModule, RouterModule, AppRoutungModule
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule { }
