import { Component, OnInit, Input } from '@angular/core';

import { CustomerOrderDetail } from '../../../models/customer-order-detail';
import { retry } from 'rxjs/operators/retry';

import { OrderService } from '../../../services/order.service';

@Component({
  selector: 'app-customer-form',
  templateUrl: './customer-form.component.html',
  styleUrls: ['./customer-form.component.css']
})
export class CustomerFormComponent implements OnInit {
  @Input() customer: CustomerOrderDetail;
  constructor(private orderService: OrderService) { }

  ngOnInit() {
  }

  findCustomerDetail() {
    this.orderService.GetCustomerDetail(this.customer.email).subscribe(res => {
      if(res) {
        this.customer.address = res.address;
        this.customer.firstName = res.firstName;
        this.customer.facebook = res.facebook;
        this.customer.lastName = res.lastName;
        this.customer.province = res.province;
        this.customer.tel = res.tel;
        this.customer.zipCode = res.zipCode;
      }
    });
  }

  provinces = [
    { value: 'กระบี่', title: 'กระบี่' },
    { value: 'กรุงเทพมหานคร', title: 'กรุงเทพมหานคร' },
    { value: 'กาญจนบุรี', title: 'กาญจนบุรี' },
    { value: 'กาฬสินธุ์', title: 'กาฬสินธุ์' },
    { value: 'กำแพงเพชร', title: 'กำแพงเพชร' },
    { value: 'ขอนแก่น', title: 'ขอนแก่น' },
    { value: 'จันทบุรี', title: 'จันทบุรี' },
    { value: 'ฉะเชิงเทรา', title: 'ฉะเชิงเทรา' },
    { value: 'ชลบุรี', title: 'ชลบุรี' },
    { value: 'ชัยนาท', title: 'ชัยนาท' },
    { value: 'ชัยภูมิ', title: 'ชัยภูมิ' },
    { value: 'ชุมพร', title: 'ชุมพร' },
    { value: 'เชียงราย', title: 'เชียงราย' },
    { value: 'เชียงใหม่', title: 'เชียงใหม่' },
    { value: 'ตรัง', title: 'ตรัง' },
    { value: 'ตราด', title: 'ตราด' },
    { value: 'ตาก', title: 'ตาก' },
    { value: 'นครนายก', title: 'นครนายก' },
    { value: 'นครปฐม', title: 'นครปฐม' },
    { value: 'นครพนม', title: 'นครพนม' },
    { value: 'นครราชสีมา', title: 'นครราชสีมา' },
    { value: 'นครศรีธรรมราช', title: 'นครศรีธรรมราช' },
    { value: 'นครสวรรค์', title: 'นครสวรรค์' },
    { value: 'นนทบุรี', title: 'นนทบุรี' },
    { value: 'นราธิวาส', title: 'นราธิวาส' },
    { value: 'น่าน', title: 'น่าน' },
    { value: 'บึงกาฬ', title: 'บึงกาฬ' },
    { value: 'บุรีรัมย์', title: 'บุรีรัมย์' },
    { value: 'ปทุมธานี', title: 'ปทุมธานี' },
    { value: 'ประจวบคีรีขันธ์', title: 'ประจวบคีรีขันธ์' },
    { value: 'ปราจีนบุรี', title: 'ปราจีนบุรี' },
    { value: 'ปัตตานี', title: 'ปัตตานี' },
    { value: 'พระนครศรีอยุธยา', title: 'พระนครศรีอยุธยา' },
    { value: 'พะเยา', title: 'พะเยา' },
    { value: 'พังงา', title: 'พังงา' },
    { value: 'พัทลุง', title: 'พัทลุง' },
    { value: 'พิจิตร', title: 'พิจิตร' },
    { value: 'พิษณุโลก', title: 'พิษณุโลก' },
    { value: 'เพชรบุรี', title: 'เพชรบุรี' },
    { value: 'เพชรบูรณ์', title: 'เพชรบูรณ์' },
    { value: 'แพร่', title: 'แพร่' },
    { value: 'ภูเก็ต', title: 'ภูเก็ต' },
    { value: 'มหาสารคาม', title: 'มหาสารคาม' },
    { value: 'มุกดาหาร', title: 'มุกดาหาร' },
    { value: 'แม่ฮ่องสอน', title: 'แม่ฮ่องสอน' },
    { value: 'ยโสธร', title: 'ยโสธร' },
    { value: 'ยะลา', title: 'ยะลา' },
    { value: 'ร้อยเอ็ด', title: 'ร้อยเอ็ด' },
    { value: 'ระนอง', title: 'ระนอง' },
    { value: 'ระยอง', title: 'ระยอง' },
    { value: 'ราชบุรี', title: 'ราชบุรี' },
    { value: 'ลพบุรี', title: 'ลพบุรี' },
    { value: 'ลำปาง', title: 'ลำปาง' },
    { value: 'ลำพูน', title: 'ลำพูน' },
    { value: 'เลย', title: 'เลย' },
    { value: 'ศรีสะเกษ', title: 'ศรีสะเกษ' },
    { value: 'สกลนคร', title: 'สกลนคร' },
    { value: 'สงขลา', title: 'สงขลา' },
    { value: 'สตูล', title: 'สตูล' },
    { value: 'สมุทรปราการ', title: 'สมุทรปราการ' },
    { value: 'สมุทรสงคราม', title: 'สมุทรสงคราม' },
    { value: 'สมุทรสาคร', title: 'สมุทรสาคร' },
    { value: 'สระแก้ว', title: 'สระแก้ว' },
    { value: 'สระบุรี', title: 'สระบุรี' },
    { value: 'สิงห์บุรี', title: 'สิงห์บุรี' },
    { value: 'สุโขทัย', title: 'สุโขทัย' },
    { value: 'สุพรรณบุรี', title: 'สุพรรณบุรี' },
    { value: 'สุราษฎร์ธานี', title: 'สุราษฎร์ธานี' },
    { value: 'สุรินทร์', title: 'สุรินทร์' },
    { value: 'หนองคาย', title: 'หนองคาย' },
    { value: 'หนองบัวลำภู', title: 'หนองบัวลำภู' },
    { value: 'อ่างทอง', title: 'อ่างทอง' },
    { value: 'อำนาจเจริญ', title: 'อำนาจเจริญ' },
    { value: 'อุดรธานี', title: 'อุดรธานี' },
    { value: 'อุตรดิตถ์', title: 'อุตรดิตถ์' },
    { value: 'อุทัยธานี', title: 'อุทัยธานี' },
    { value: 'อุบลราชธานี', title: 'อุบลราชธานี' }
  ]

}
