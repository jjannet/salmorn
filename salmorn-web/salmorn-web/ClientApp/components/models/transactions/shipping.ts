
import { Order } from './order';

export class Role {
    id: number;
    trackingCode: string;
    orderId: number;
    orderCode: string;
    isActive: Boolean;
    isShipping: Boolean;
    shippingDate: Date;
    email: string;
    tel: string;
    firstName: string;
    lastName: string;
    address: string;
    province: string;
    zipCode: string;
    createDate: Date;
    createBy: number;
    updateDate: Date;
    updateBy: number;
    printCoverQty: number;


    order: Order;
}