
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map'
import 'rxjs/Rx';
import { Response } from '@angular/http'
import { JhttpService } from '../shared/services/jhttp.service';

import { FileUpload } from '../models/file-upload';

@Injectable()
export class PaymentService {

  constructor(private http: JhttpService) { }

  postFile(fileToUpload: File): Observable<FileUpload> {
    let input = new FormData();
    input.append("fileSelect", fileToUpload);
    input.append("file", fileToUpload.name);
    return this.http
      .post('/api/Payment/uploadPaymentSlip', input)
      .map((res: Response) => res.json() as FileUpload);
  }

}

