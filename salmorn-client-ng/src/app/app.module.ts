import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CoreModule } from './core/core.module';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http'
import { FormsModule } from '@angular/forms';

import { SharedModule } from './shared/shared.module';
import { ServicesModule } from './services/services.module';

import { AppComponent } from './app.component';
import { AppRoutungModule } from './app-router';
import { OnlyNumberDirective } from './directives/only-number.directive';

import 'reflect-metadata';

@NgModule({
  declarations: [
    AppComponent,
    OnlyNumberDirective,
  ],
  imports: [
    BrowserModule,FormsModule, CoreModule, RouterModule, AppRoutungModule, SharedModule, ServicesModule, HttpModule
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule { }
