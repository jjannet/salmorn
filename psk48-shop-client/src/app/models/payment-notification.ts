import { FileUpload } from './file-upload';
export class PaymentNotification {

    id: number;
    fileId: number;
    firstName: string;
    lastName: string;
    orderCode: string;
    paymentDate: Date;
    paymentType: string;
    isActive: Boolean;
    isMapping: Boolean;
    money: number;

    file: FileUpload;
}