import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { NonNullableFormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { TranslateDirective, TranslatePipe, TranslateService } from '@ngx-translate/core';

import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzFlexModule } from 'ng-zorro-antd/flex';
import { loginRequestDto } from '../../../models/DTOs/LoginDtos';
import { authConstants } from '../../../models/Constants/authConstants';
import { UserInfoService } from '../../../services/state/user-info.service';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/repos/Auth/auth.service';

@Component({
  selector: 'app-login',
  imports: [
    ReactiveFormsModule,
    NzFormModule,
    NzInputModule,
    NzButtonModule,
    NzFlexModule,
    TranslatePipe
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  loginForm: FormGroup

  constructor(formBuilder: FormBuilder, 
              private authService:AuthService,
              private userState: UserInfoService,
              private router: Router){
    this.loginForm = formBuilder.group({
      email: ['',[Validators.required,Validators.email]],
      password: ['',[Validators.required,Validators.minLength(8)]]
    })
  }

  submitForm(){
    let loginRequest: loginRequestDto = {
      email: this.email?.value,
      password: this.password?.value
    }

    this.authService.login(loginRequest)
                    .subscribe(r => {
                      if(r.isSuccess == true)
                      {
                        if(r.userInfo.isActive){
                          localStorage.setItem(authConstants.AUTH_TOKEN,r.token)
                          localStorage.setItem(authConstants.USER, JSON.stringify(r.userInfo))
                          this.userState.setState(r.userInfo)
                          this.router.navigate(['/dashboard'])
                        }
                      }
                    })
    
  }

  navigateSignUp(){
    this.router.navigate(['/auth/register'])
  }

  get email(){
    return this.loginForm.get('email')
  }

  get password(){
    return this.loginForm.get('password')
  }

}
