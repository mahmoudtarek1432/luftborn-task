import { Component } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ReactiveFormsModule, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { TranslatePipe } from '@ngx-translate/core';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzFlexModule } from 'ng-zorro-antd/flex';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzInputModule } from 'ng-zorro-antd/input';
import { loginRequestDto } from '../../../models/DTOs/LoginDtos';
import { authConstants } from '../../../models/Constants/authConstants';
import { RegisterRequest } from '../../../models/DTOs/RegisterDtos';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/repos/Auth/auth.service';

@Component({
  selector: 'app-register',
  imports: [
      ReactiveFormsModule,
      NzFormModule,
      NzInputModule,
      NzButtonModule,
      NzFlexModule,
      TranslatePipe
  ],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {
  registerForm: FormGroup

  constructor(formBuilder: FormBuilder, private authService: AuthService, private router: Router){
    this.registerForm = formBuilder.group({
      businessNameEN: ['',[Validators.required]],
      businessNameAR: ['',[Validators.required]],
      email: ['',[Validators.required,Validators.email]],
      mobileNumber: ['',[Validators.required]],
      password: ['',[Validators.required,Validators.minLength(8)]],
      confirmPassword: ['',[Validators.required,this.comparePassword]],

    })
  }

  submitForm(){
    let registerRequest = {
      firstName: "temp",
      lastName: "temp",
      companyARName: this.businessNameAR?.value,
      companyEnName: this.businessNameEN?.value,
      password: this.password?.value,
      confirmPassword: this.confirmPassword?.value,
      email: this.email?.value,
      mobile: this.mobileNumber?.value
    } as RegisterRequest

    this.authService.Register(registerRequest)
                    .subscribe(r => 
                      {
                        if(r.isSuccess){
                          this.router.navigate(['/auth/login'])
                        } 
                      })
  }

  comparePassword():ValidatorFn {
    return (control:AbstractControl): ValidationErrors | null => {
      return control.value == this.password?.value ? {equal: true} : null
    }
  }

  navigateLogin(){
    this.router.navigate(['/auth/login'])
  }

  get businessNameEN(){
    return this.registerForm.get('businessNameEN')
  }

  get businessNameAR(){
    return this.registerForm.get('businessNameAR')
  }

  get email(){
    return this.registerForm.get('email')
  }

  get mobileNumber(){
    return this.registerForm.get('mobileNumber')
  }

  get password(){
    return this.registerForm.get('password')
  }

  get confirmPassword(){
    return this.registerForm.get('confirmPassword')
  }

}
