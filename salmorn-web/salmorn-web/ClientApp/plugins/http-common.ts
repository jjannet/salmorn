import axios from 'axios';
import { Storages } from '../Commons/local-storage';



export const HTTP = axios.create({
    baseURL: `http://localhost:56363/`,
    headers: {
        Authorization: 'Bearer ' + Storages.getTokenData()
    }
})
//    .interceptors.response.use((response) => {
//    return response;
//    }, function (error) {
//        console.log('Request Error: ', error);
//    // Do something with response error
//    if (error.response.status === 401) {
//        console.log('unauthorized, logging out ...');
//    }
//    return error;
//});