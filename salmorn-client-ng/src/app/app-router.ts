import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PageNotFoundComponent } from './pages/page-not-found/page-not-found.component';

export const routes: Routes = 
    [
        {
            path: '',
            loadChildren: 'app/pages/home/home.module#HomeModule',
            pathMatch: 'full'
        },
        
        {
            path: 'news',
            loadChildren: 'app/pages/news/news.module#NewsModule',
            pathMatch: 'full'
        },
        
        {
            path: 'activities',
            loadChildren: 'app/pages/activity/activity.module#ActivityModule',
            pathMatch: 'full'
        },
        
        {
            path: 'goods',
            loadChildren: 'app/pages/goods/goods.module#GoodsModule',
            pathMatch: 'full'
        },
        
        {
            path: 'goods/:id',
            loadChildren: 'app/pages/goods-detail/goods-detail.module#GoodsDetailModule',
            pathMatch: 'full'
        },
        
        {
            path: 'gallery',
            loadChildren: 'app/pages/gallery/gallery.module#GalleryModule',
            pathMatch: 'full'
        },
        
        {
            path: 'live',
            loadChildren: 'app/pages/live/live.module#LiveModule',
            pathMatch: 'full'
        },
        
        {
            path: 'cart',
            loadChildren: 'app/pages/cart-detail/cart-detail.module#CartDetailModule',
            pathMatch: 'full'
        },
      
        {
            path: '**',
            component: PageNotFoundComponent
        }
    ]


@NgModule({
    imports: [RouterModule.forRoot(routes)],
    declarations: [PageNotFoundComponent],
    exports: [
        RouterModule
    ]
})

export class AppRoutungModule{}