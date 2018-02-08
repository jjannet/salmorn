import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { NgForm } from '@angular/forms';

import { OrderService } from '../../services/order.service';
import { PaymentService } from '../../services/payment.service';

import { PaymentNotification } from '../../models/payment-notification';
import { FileUpload } from '../../models/file-upload';
import { retry } from 'rxjs/operator/retry';

@Component({
  selector: 'app-confirm-payment',
  templateUrl: './confirm-payment.component.html',
  styleUrls: ['./confirm-payment.component.css']
})
export class ConfirmPaymentComponent implements OnInit {
  private sub: any;
  fileToUpload: File = null;

  constructor(private route: ActivatedRoute, private orderService: OrderService, private paymentService: PaymentService, private router: Router) { }
  payment: PaymentNotification;
  isSetOrderCode: boolean = false;;
  hour: string;
  minute: string;
  hours: Array<number> = [];
  minutes: Array<number> = [];
  payDate: string;

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      for (let i = 0; i < 24; i++) {
        this.hours.push(i);
      }
      for (let i = 0; i < 60; i++) {
        this.minutes.push(i);
      }

      // let currentDate = new Date();
      // this.payment = this.genBlankPayment();
      // this.hour = currentDate.getHours().toString();
      // this.minute = currentDate.getMinutes().toString();
      //this.payDate = currentDate.getFullYear().toString() + '-' +  this.pad((currentDate.getMonth() + 1), 2) + '-' + this.pad(currentDate.getDate(), 2);

      this.clearPaymentData();

      this.payment.orderCode = params['orderCode'];

      if (this.payment.orderCode) {
        this.setOrderCode(null);
      } else {
        this.isSetOrderCode = false;
      }
    });



  }

  ngOnDestroy() {
  }


  uploadSlip(files: FileList) {
    let fileToUpload: File = files.item(0);
    this.loading(true);
    this.paymentService.postFile(fileToUpload).subscribe(
      res => {
        if (res != null) {
          this.payment.file = res;
        } else {
          alert('Upload file error');
        }
        this.loading(false);
      },
      msg => {
        console.error(msg)

        this.loading(false);
      });
  }


  setOrderCode(f: NgForm) {
    if (!f || f.valid) {
      this.loading(true);
      this.orderService.getOrderByCode(this.payment.orderCode)
        .subscribe(
        res => {
          if (res) {
            this.payment.firstName = res.firstName;
            this.payment.lastName = res.firstName;
            this.payment.orderCode = res.code;
            this.isSetOrderCode = true;
          } else {
            this.isSetOrderCode = false;
          }
          this.loading(false);
        },
        msg => {
          console.error(msg)

          this.loading(false);
        });
    }
  }

  confirm(f: NgForm) {
    if (f.valid) {
      if (this.payment.money <= 0) {
        alert('จำนวนเงินที่โอน ต้องมีค่ามากกว่า 0'); return;
      }


      if (this.payment.file) {
        this.loading(true);
        this.payment.paymentDate = new Date(`${this.payDate}T${this.pad(Number(this.hour), 2)}:${this.pad(Number(this.minute), 2)}:00`);
        this.payment.fileId = this.payment.file.id;
        this.orderService.addPayment(this.payment)
          .subscribe(
          res => {
            console.log(res);
            if (res == 1) {
              this.router.navigate(['/confirm-payment/complete']);
            } else {
              alert('ไม่พบ Order code');
            }
            this.loading(false);
          },
          msg => {
            console.error('Error: ', msg)

            this.loading(false);
          });

      } else {
        alert('กรุณา upload หลักฐานการโอนเงิน');
      }
    }
  }

  clearPaymentData() {
    let currentDate = new Date();
    this.payment = this.genBlankPayment();

    this.payment = this.genBlankPayment();
    this.hour = currentDate.getHours().toString();
    this.minute = currentDate.getMinutes().toString();
    this.isSetOrderCode = false;

  }

  pad(num: number, size: number): string {
    let s = num + "";
    while (s.length < size) s = "0" + s;
    return s;
  }

  loading(isLoading: boolean) {
    if (isLoading)
      document.getElementById('loading').style.display = 'block';
    else
      document.getElementById('loading').style.display = 'none';
  }

  genBlankPayment(): PaymentNotification {
    return {
      file: null, fileId: null, firstName: '', id: -1, isActive: true, isMapping: false, lastName: '', money: 0
      , orderCode: '', paymentDate: new Date(), paymentType: 'TRANSFER'
    };
  }

  getMockupFile(): FileUpload {
    return {
      fileName: 'https://storage.googleapis.com/order-payment-slip/W7VBGO63TLNTDUCGRKNJUSHNRZSLK0.png',
      id: 10024,
      ipAddress: '127.0.0.1',
      macAddress: '',
      type: 'SLIP',
      uploadDate: new Date,
      userId: -1
    };
  }
}
