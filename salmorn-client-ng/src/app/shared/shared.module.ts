import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { JhttpService } from './services/jhttp.service';
import { TokenManageService } from './services/token-manage.service';

@NgModule({
  providers: [
    JhttpService, TokenManageService,
],
  imports: [
    CommonModule
  ],
  declarations: []
})
export class SharedModule { }
