import { Component, OnInit } from '@angular/core';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  images: string[] = [
    '../contents/images/top-slider/01.jpg',
    '../contents/images/top-slider/02.JPG',
    '../contents/images/top-slider/03.jpg',
  ];

  index: number;

  constructor(private route:Router) { }

  ngOnInit() {
    this.index = 0;
    let slide = document.getElementById('topHeaderSlide');

    this.changeImage(slide);
  }

  changeImage(slide: HTMLElement) {

    setTimeout(() => {

      this.index++;

      if (this.index >= this.images.length) this.index = 0;
      this.changeImage(slide);

    },
      10000);

  }

  gotoHome() {
    this.route.navigate(['goods']);
  }

  getImageUrl() {
    return "url(" + this.images[this.index] + ")";
  }

}
