import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment.development';
import { ListUser } from '../../../models/DTOs/listUser';
import { BaseResponse } from '../../../models/DTOs/BaseResponse';
import { listUserResponse } from '../../../models/DTOs/ListUserResponse';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  userList(){
    return this.http.get<listUserResponse>(environment.baseUrl+'users')
  }

  deleteUser(id: string){
    return this.http.delete<BaseResponse<unknown>>(environment.baseUrl+'user/'+id)
  }

  changeRole(id: string, role: string){
    return this.http.put<BaseResponse<unknown>>(environment.baseUrl+'user/'+id+'/role/'+role,{})
  }
}
