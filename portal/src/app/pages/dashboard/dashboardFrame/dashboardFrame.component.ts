import { Component } from '@angular/core';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import { TranslatePipe } from '@ngx-translate/core';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd/menu';

@Component({
  selector: 'app-dashboardFrame',
  imports: [RouterOutlet, TranslatePipe, NzIconModule, NzLayoutModule, NzMenuModule],
  templateUrl: './dashboardFrame.component.html',
  styleUrl: './dashboardFrame.component.scss'
})
export class DashboardComponent {
  isCollapsed = false;

  constructor(private router: Router) {
    
  }

  navigateUsers(){
    this.router.navigate(['dashboard/users']);
  }
}