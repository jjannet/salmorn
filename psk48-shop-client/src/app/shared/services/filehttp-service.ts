import { Injectable } from '@angular/core';
import {
  Http,XHRBackend,RequestOptions,Request,RequestOptionsArgs,Response,Headers
} from '@angular/http'
import { Observable } from 'rxjs/Observable';

import { TokenManageService } from './token-manage.service';

@Injectable()
export class FilehttpService extends Http {
  tokenService: TokenManageService;
  constructor(backend: XHRBackend, options: RequestOptions, tokenService: TokenManageService) {
    const token = tokenService.getToken();
    //options.headers.set('Authorization', `Bearer ${token}`)
    options.headers.delete('Content-Type')

    super(backend, options);
  }

  request(
    url: string | Request,
    options?: RequestOptionsArgs
  ): Observable<Response>{

    // const token = localStorage.getItem('access-token');

    // if(typeof url === 'string'){
    //   if(!options) options = { headers: new Headers() };
    //   options.headers.set('Authorization', `Bearer ${token}`);
    //   options.headers.set('Content-Type', `application/json`);
    // }else{
    //   url.headers.set('Authorization', `Bearer ${token}`);
    //   url.headers.set('Content-Type', `application/json`);
    // } 

    return super.request(url, options);
  }
}
