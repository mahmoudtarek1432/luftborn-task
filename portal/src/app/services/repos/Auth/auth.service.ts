import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { loginRequestDto, loginResponseDto } from '../../../models/DTOs/LoginDtos';
import { environment } from '../../../../environments/environment.development';
import { RegisterRequest, RegisterResponse } from '../../../models/DTOs/RegisterDtos';
import { BaseResponse } from '../../../models/DTOs/BaseResponse';
import { authConstants } from '../../../models/Constants/authConstants';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  login(request: loginRequestDto):Observable<loginResponseDto>
  {
    return this.http.post<loginResponseDto>(environment.baseUrl+'auth/login', request)
  }

  Register(request: RegisterRequest):Observable<RegisterResponse>
  {
    return this.http.post<RegisterResponse>(environment.baseUrl+'auth/Register', request)
  }

  isLoggedIn(): boolean{
    return !!localStorage.getItem(authConstants.AUTH_TOKEN)
  }
}
