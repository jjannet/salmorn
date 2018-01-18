import Vue from 'vue';
import { HTTP } from '../../plugins/http-common';
import { Component } from 'vue-property-decorator';

@Component
export default class CounterComponent extends Vue {
    currentcount: number = 0;

    incrementCounter() {
        this.currentcount++;
    }

    created() {
        HTTP.post(`api/SampleData/getStr`)
            .then(response => {
                console.log(response.data)
            })
            .catch(e => {
                console.error(e)
            })
    }
}
