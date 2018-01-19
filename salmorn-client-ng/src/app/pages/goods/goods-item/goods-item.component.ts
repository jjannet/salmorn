import { Component, OnInit, Input } from '@angular/core';
import { Router, RouterModule } from '@angular/router';

import { Product } from '../../../models/product';
import { retry } from 'rxjs/operator/retry';

@Component({
  selector: '[app-goods-item]',
  templateUrl: './goods-item.component.html',
  styleUrls: ['./goods-item.component.css']
})
export class GoodsItemComponent implements OnInit {

  @Input() product: Product;

  constructor(private route:Router) { }

  ngOnInit() {
  }

  getImagePath(product: Product) : string {
    if(product.images.length > 0) {
      return product.images[0].fileName;
    }else return '../contents/images/no-image.jpg';
  }

  errorHandler(event) {
    event.target.src = "../contents/images/no-image.jpg";
  }


  viewDetail(product: Product) {
    this.route.navigate([`/goods/${product.id}`]);
  }
}
