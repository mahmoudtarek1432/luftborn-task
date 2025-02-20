import { BaseResponse } from "./BaseResponse";

export interface RegisterRequest {
    firstName: string;
    lastName: string;
    companyEnName: string;
    companyARName: string;
    mobile: string;
    email: string;
    password: string;
    confirmPassword: string;
}

export interface RegisterResponse extends BaseResponse<unknown>{
    
}