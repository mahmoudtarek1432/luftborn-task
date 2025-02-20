import { UserLogin } from "../entities/UserLogin";
import { BaseResponse } from "./BaseResponse";

export interface loginRequestDto{
    email: string
    password: string
}

export interface loginResponseDto extends BaseResponse<unknown>{
    token: string;
    userInfo: UserLogin
}