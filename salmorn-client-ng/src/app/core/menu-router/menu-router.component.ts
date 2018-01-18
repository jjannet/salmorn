import { Component, OnInit } from '@angular/core';
import { Router, RouterModule } from '@angular/router';

import { MenuRouterItemComponent } from './menu-router-item/menu-router-item.component';

import { MenuItem } from '../models/menu-item';

@Component({
  selector: 'app-menu-router',
  templateUrl: './menu-router.component.html',
  styleUrls: ['./menu-router.component.css']
})
export class MenuRouterComponent implements OnInit {

  menues: MenuItem[] = [
    { link: '/', name: 'Home' }
    , { link: '/news', name: 'News' }
    , { link: '/activities', name: 'Activities' }
    , { link: '/goods', name: 'Goods' }
    , { link: '/gallery', name: 'Gallery' }
    , { link: '/live', name: 'Salmorn live' }
  ];

  constructor(private route:Router) { }

  ngOnInit() {
  }

  enterLink(link: string) {
    this.route.navigate([link]);
  }

}
