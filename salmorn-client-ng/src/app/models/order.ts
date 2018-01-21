import { Product } from './product';
import { PaymentNotification } from './payment-notification';

export class Order {
    id?: number;
    code?: string;
    paymentId?: number;
    orderDate?: Date;
    productId: number;
    qty: number;
    unitPrice?: number;
    totalPrice?: number;
    totalProductPrice?: number;
    isPay?: Boolean;
    payDate?: Date;
    isShipping: Boolean;
    shippingDateStart?: Date;
    shippingDateEnd?: Date;
    shippingDate?: Date;
    shippingPrice?: number;
    tel: string;
    email: string;
    firstName: string;
    lastName: string;
    address: string;
    province: string;
    zipCode: string;
    isMeetReceive: Boolean;
    isActive: Boolean;
    isCreateShipping?: Boolean;
    isFinish?: Boolean;
    createBy?: number;
    createDate?: Date;
    updateBy?: number;
    updateDate?: Date;

    product: Product;
    payment?: PaymentNotification;
}