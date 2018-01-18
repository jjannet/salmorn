import Vue from 'vue';
import { HTTP } from '../../plugins/http-common';
import { Component } from 'vue-property-decorator';

import { Product } from '../models/masters/product';
import { ViewFormat } from '../Utils/view-format';

@Component
export default class GoodsComponent extends Vue {
    currentcount: number = 0;
    viewFormat: ViewFormat;

    products: Array<Product> = [];

    incrementCounter() {
        this.currentcount++;
    }
     
    created() {
        //products = new Array<Product>();
        HTTP.get(`api/ProductServices/getProducts`)
            .then(response => {
                this.products = response.data as Array<Product>;
            })
            .catch(e => {
                console.error(e)
            })
    }

    getImagePath(product: Product) : string {
        if (product && product.images && product.images.length > 0) {
            return product.images[0].fileName;
        } else {
            return '';
        }
    }

    formatPrice(value: number): string {
        let val = (value / 1).toFixed(0).replace('.', ',')
        return val.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",")
    }

    dateFormat(date: Date(): string  {
        ViewFormat.
    }
}
