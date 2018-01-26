import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { JhttpService } from './services/jhttp.service';
import { FilehttpService } from './services/filehttp-service';
import { TokenManageService } from './services/token-manage.service';

@NgModule({
  providers: [
    JhttpService, FilehttpService, TokenManageService,
],
  imports: [
    CommonModule
  ],
  declarations: []
})
export class SharedModule { }
