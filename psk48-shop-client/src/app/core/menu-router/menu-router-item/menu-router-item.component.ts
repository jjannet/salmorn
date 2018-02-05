import { Component, OnInit, Input } from '@angular/core';
import { Router, RouterModule } from '@angular/router';

import { MenuItem } from '../../models/menu-item';

@Component({
  selector: '[app-menu-router-item]',
  templateUrl: './menu-router-item.component.html',
  styleUrls: ['./menu-router-item.component.css']
})
export class MenuRouterItemComponent implements OnInit {

  @Input() item : MenuItem;
  constructor(private route:Router) { }

  ngOnInit() {
  }

  enterLink(item: MenuItem) {
    this.route.navigate([item.link]);
  }

}
