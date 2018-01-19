import { FileUpload } from './file-upload';

export class Product {
    id: number;
    code: string;
    cost: number;
    createBy: number;
    createDate: Date;
    detail: string;
    isActive: Boolean;
    isPreOrder: Boolean;
    isUseStock: Boolean;
    name: string;
    note: string;
    preEnd: Date;
    preStart: Date;
    price: number;
    qtyShippingPriceCeiling: number;
    shippintPriceRate: number;
    unitName: string;
    updateBy: number;
    updateDate: Date;
    weight: number;
    isDelete: Boolean;
    isManualPickup: Boolean;
    pickupAt: string;
    stockQrty: number;

    images: Array<FileUpload>;
}