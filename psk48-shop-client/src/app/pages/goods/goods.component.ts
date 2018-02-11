import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../services/product.service';

import {  Product } from '../../models/product';

@Component({
  selector: 'app-goods',
  templateUrl: './goods.component.html',
  styleUrls: ['./goods.component.css']
})
export class GoodsComponent implements OnInit {
  products: Array<Product>;
  constructor(private service: ProductService) { }

  ngOnInit() {
    this.loadProduct();
    // document.getElementById('appHeader').style.display = 'none';
  }

  ngOnDestroy() {
    // document.getElementById('appHeader').style.display = 'block';
  }

  loadProduct() {
    this.loading(true);
    this.service.GetAll().subscribe(res => {
      this.products = res;
      this.loading(false);
      //this.productForm.setValue(this._convertProductToFromProductModel(this.product));
    });
  }


  loading(isLoading: boolean) {
    if (isLoading)
      document.getElementById('loading').style.display = 'block';
    else
      document.getElementById('loading').style.display = 'none';
  }
}
