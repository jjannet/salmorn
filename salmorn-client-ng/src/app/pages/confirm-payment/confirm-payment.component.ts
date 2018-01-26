import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';

import { OrderService } from '../../services/order.service';
import { PaymentService } from '../../services/payment.service';

import { PaymentNotification } from '../../models/payment-notification';
import { FileUpload } from '../../models/file-upload';

@Component({
  selector: 'app-confirm-payment',
  templateUrl: './confirm-payment.component.html',
  styleUrls: ['./confirm-payment.component.css']
})
export class ConfirmPaymentComponent implements OnInit {
  private sub: any;
  fileToUpload: File = null;

  constructor(private route: ActivatedRoute, private orderService: OrderService, private paymentService: PaymentService) { }
  payment: PaymentNotification;
  isSetOrderCode: boolean = false;;
  hour: string;
  minute: string;
  hours: Array<number> = [];
  minutes: Array<number> = [];
  payDate: string;

  ngOnInit() {
    document.getElementById('appHeader').style.display = 'none';
    this.sub = this.route.params.subscribe(params => {
      for (let i = 0; i < 24; i++) {
        this.hours.push(i);
      }
      for (let i = 0; i < 60; i++) {
        this.minutes.push(i);
      }
      let currentDate = new Date();

      this.payment = this.genBlankPayment();
      this.hour = currentDate.getHours().toString();
      this.minute = currentDate.getMinutes().toString();
      //this.payDate = currentDate.getFullYear().toString() + '-' +  this.pad((currentDate.getMonth() + 1), 2) + '-' + this.pad(currentDate.getDate(), 2);


      this.payment.orderCode = params['orderCode'];

      if (this.payment.orderCode) {
        this.setOrderCode(null);
      } else {
        this.isSetOrderCode = false;
      }
    });



  }

  ngOnDestroy() {
    document.getElementById('appHeader').style.display = 'block';
  }


  uploadSlip(files: FileList) {
    let fileToUpload: File = files.item(0);
    this.paymentService.postFile(fileToUpload).subscribe(res => {
      console.log(res);
    },
    msg => console.error(`Error: ${msg.status} ${msg.statusText}`));
  }

  getBase64(file: File) {
    var reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = function () {
      console.log(reader.result);
    };
    reader.onerror = function (error) {
      console.log('Error: ', error);
    };
 }

  setOrderCode(f: NgForm) {
    if (!f || f.valid) {
      this.orderService.getOrderByCode(this.payment.orderCode).subscribe(res => {
        if (res) {
          this.payment.firstName = res.firstName;
          this.payment.lastName = res.firstName;
          this.payment.orderCode = res.code;
          this.isSetOrderCode = true;
        } else {
          this.isSetOrderCode = false;
        }
      });
    }
  }


  pad(num: number, size: number): string {
    let s = num + "";
    while (s.length < size) s = "0" + s;
    return s;
  }


  genBlankPayment(): PaymentNotification {
    return {
      file: null, fileId: null, firstName: '', id: -1, isActive: true, isMapping: false, lastName: '', money: 0
      , orderCode: '', paymentDate: new Date(), paymentType: 'TRANSFER'
    };
  }
}
