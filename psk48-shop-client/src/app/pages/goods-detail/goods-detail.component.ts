import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ProductService } from '../../services/product.service';

import { Product } from '../../models/product';
import { retry } from 'rxjs/operators/retry';

@Component({
  selector: 'app-goods-detail',
  templateUrl: './goods-detail.component.html',
  styleUrls: ['./goods-detail.component.css']
})
export class GoodsDetailComponent implements OnInit {
  id: number;
  private sub: any;
  product: Product;
  orderQty: number = 1;

  constructor(private route: ActivatedRoute, private service: ProductService) { }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id']; // (+) converts string 'id' to a number
      console.log('id', this.id);
      // In a real app: dispatch action to load the details here.
      this.loadProduct();
    });
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  loadProduct() {
    this.service.Get(this.id).subscribe(res => {
      this.product = res;
      console.log(this.product);
    });
  }

  getImagePath(product: Product): string {
    if(!product) return '';
    if (product.images.length > 0) {
      return product.images[0].fileName;
    } else return '../contents/images/no-image.jpg';
  }

  errorHandler(event) {
    event.target.src = "../contents/images/no-image.jpg";
  }

}
