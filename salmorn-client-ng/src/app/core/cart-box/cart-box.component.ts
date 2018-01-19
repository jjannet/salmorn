import { Component, OnInit } from '@angular/core';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: '[app-cart-box]',
  templateUrl: './cart-box.component.html',
  styleUrls: ['./cart-box.component.css']
})
export class CartBoxComponent implements OnInit {

  constructor(private route:Router) { }

  ngOnInit() {
  }

  gotoSummary(){
    this.route.navigate(['summary']);
  }
}
