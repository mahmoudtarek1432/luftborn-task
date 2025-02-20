export class BaseResponse<T> {
    isSuccess!: boolean;
    message!: string;
    data!: T
}