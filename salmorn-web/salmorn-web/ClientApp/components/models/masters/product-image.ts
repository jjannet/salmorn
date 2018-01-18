import { FileUpload } from '../logs/file-upload';

export class ProductImage {
    id: number;
    fileId: number;
    productId: number;

    images: Array<FileUpload>;
}