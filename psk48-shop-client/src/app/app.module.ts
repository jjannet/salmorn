import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CoreModule } from './core/core.module';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http'
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HttpRequest, HTTP_INTERCEPTORS } from '@angular/common/http';
import {Request, XHRBackend, XHRConnection} from '@angular/http';

import { SharedModule } from './shared/shared.module';
import { ServicesModule } from './services/services.module';

import { APIInterceptor,ApiXHRBackend  } from './APIInterceptor';
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
  providers: [  
    {
    provide: HTTP_INTERCEPTORS,
    useClass: APIInterceptor,
  }, 
  { provide: XHRBackend, useClass: ApiXHRBackend }],
  bootstrap: [AppComponent],
})
export class AppModule { }
