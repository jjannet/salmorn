
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map'
import 'rxjs/Rx';
import { JhttpService } from '../shared/services/jhttp.service';
import { FilehttpService } from '../shared/services/filehttp-service';
import {
  Http,XHRBackend,RequestOptions,Request,RequestOptionsArgs,Response,Headers
} from '@angular/http'

import { PaymentNotification } from '../models/payment-notification';
import { FileUpload } from '../models/file-upload';

@Injectable()
export class PaymentService {

  constructor(private http: JhttpService, private fileHttp: FilehttpService) { }

  postFile(fileToUpload: File): Observable<FileUpload> {
    let input = new FormData();
    input.append("file", fileToUpload);
    return this.fileHttp
      .post('/api/Payment/uploadPaymentSlip', input)
      .map((res: Response) => res.json() as FileUpload);
  }

  confirmPayment(payment: PaymentNotification): Observable<number> {
    return  this.http
                .post('/api/Payment/ConfirmPayment', payment)
                .map((res: Response) => res.json() as number);;
  }
}

