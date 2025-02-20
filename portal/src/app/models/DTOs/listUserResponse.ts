import { BaseResponse } from "./BaseResponse";
import { ListUser } from "./listUser";

export interface listUserResponse extends BaseResponse<unknown>{
    users: ListUser[]
}