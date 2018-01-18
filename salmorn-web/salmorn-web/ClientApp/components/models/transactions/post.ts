
import { PostType } from '../masters/post-type';

export class Post {
    id: number;
    title: string;
    detail: string;
    typeId: number;
    isActive: Boolean;
    author: string;
    authorId: number;
    targetDate: Date;
    createDate: Date;
    updateDate: Date;
    updateBy: number;
    select: Boolean;

    postType: PostType;
}