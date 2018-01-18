



export const routes = [
    { path: '/', component: require('./components/home/home.vue.html') },
    { path: '/news', component: require('./components/news/news.vue.html') },

    { path: '/goods', component: require('./components/goods/goods.vue.html') },
    { path: '/goods/:id', component: require('./components/goods/goods-item/goods-item.vue.html') },

    { path: '/galleries', component: require('./components/galleries/galleries.vue.html') },
    { path: '/live', component: require('./components/live/live.vue.html') },
    { path: '/counter', component: require('./components/counter/counter.vue.html') },
    { path: '/fetchdata', component: require('./components/fetchdata/fetchdata.vue.html') }
];