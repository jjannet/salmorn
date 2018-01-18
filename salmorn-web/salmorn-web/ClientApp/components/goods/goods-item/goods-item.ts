import Vue from 'vue';
import { HTTP } from '../../../plugins/http-common';
import { Component } from 'vue-property-decorator';

@Component
export default class GoodsItemComponent extends Vue {
    currentcount: number = 0;

    incrementCounter() {
        this.currentcount++;
    }

    created() {
       
    }

    formatPrice(value: number): string {
        let val = (value / 1).toFixed(2).replace('.', ',')
        return val.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")
    }
}
