import {Injectable} from '@angular/core';
import {HttpEvent, HttpInterceptor, HttpHandler, HttpRequest} from '@angular/common/http';
import {Request, XHRBackend, XHRConnection} from '@angular/http';
import {Observable} from 'rxjs/Observable';


const baseUrl = 'http://service.paisuekong.com'; 

@Injectable()
export class APIInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    const apiReq = req.clone({ url: `${baseUrl}/${req.url}` });

    console.log('apiReq', apiReq)

    return next.handle(apiReq);
  }
}


@Injectable()
export class ApiXHRBackend extends XHRBackend {
    createConnection(request: Request): XHRConnection {
        if (request.url.startsWith('/')){
            request.url = baseUrl + request.url;     // prefix base url
        }
        console.log('request.url', request.url)
        return super.createConnection(request);
    }
}