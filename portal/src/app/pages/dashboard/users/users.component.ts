import { Component } from '@angular/core';
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { ListUser } from '../../../models/DTOs/listUser';
import { role } from '../../../models/Constants/roles';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { UserService } from '../../../services/repos/User/user.service';
import { Observable } from 'rxjs';
import { listUserResponse } from '../../../models/DTOs/ListUserResponse';
import { UserInfoService } from '../../../services/state/user-info.service';
import { UserLogin } from '../../../models/entities/UserLogin';

@Component({
  selector: 'app-users',
  imports: [NzTableModule,NzSelectModule, NzButtonModule, FormsModule, NzDividerModule, CommonModule],
  templateUrl: './users.component.html',
  styleUrl: './users.component.scss'
})

export class UsersComponent {
  roles = role;
  userlist!: ListUser[]
  userInfo!: UserLogin
  constructor(private userService: UserService, private userState: UserInfoService){
    userService.userList().subscribe(r => {
      this.userlist = r.users.map(e => {return {...e,selectedRole: e.role} })
    });
    this.userInfo = userState.getState()
    console.log(this.userInfo)
  }

  deleteUser(id: string){
    this.userService.deleteUser(id)
                    .subscribe(r => {
                      if(r.isSuccess == true){
                        this.userlist = this.userlist.filter(e => e.id != id)
                      }
                    });
  }

  userCanEdit(){
    return this.userInfo.role == 'ADMIN'
  }

  rowCanBeEdited(userRowId: string){
    return userRowId != this.userInfo.id
  }
}
