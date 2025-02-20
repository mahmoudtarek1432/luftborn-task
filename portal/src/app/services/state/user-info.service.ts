import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { UserLogin } from '../../models/entities/UserLogin';

@Injectable({
  providedIn: 'root'
})
export class UserInfoService {

  private  userSubject = new BehaviorSubject<UserLogin>({} as UserLogin);
  
  $user(){
      return this.userSubject.asObservable()
  }

  getState(){
    return this.userSubject.getValue()
  }

  setState(user:UserLogin){
    return this.userSubject.next(user)
  }
}
