import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map'
import 'rxjs/Rx';
import { Response } from '@angular/http'
import { JhttpService } from '../shared/services/jhttp.service';
import { Product } from '../models/product';

@Injectable()
export class ProductService {
  constructor(private http: JhttpService) { }

  GetAll(): Observable<Array<Product>> {
    return this.http.get(`/api/Product`).map((res: Response) => res.json() as Array<Product>);
  }

  Get(id: number): Observable<Product> {
    return this.http.get(`/api/Product/${id}`).map((res: Response) => res.json() as Product);
  }

}
