import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterLink, RouterOutlet } from '@angular/router';
import { TranslateDirective, TranslatePipe, TranslateService } from '@ngx-translate/core';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzMessageService } from 'ng-zorro-antd/message';
import { TranslationUtil } from './utilities/translationConfig';
import { ToastStateService } from './services/state/ToastState.service';

@Component({
  selector: 'app-root',
  imports: [RouterLink,
            RouterOutlet,
            NzIconModule,
            NzLayoutModule,
            NzMenuModule,
          ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  isCollapsed = false;
  direction!:string
  constructor(private translateService: TranslateService,
    private activeRoute: ActivatedRoute,
    private toastState: ToastStateService,
     private messageSerivce: NzMessageService){
    this.translationInit();
    this.toastMessageInit();
  }

  ngOnInit(): void {
    this.activeRoute.queryParams.subscribe(q => {
      let transUtil = new TranslationUtil(this.translateService);
      transUtil.translationLanguage = q['lang']
    })
  }

  translationInit(){
    let transUtil = new TranslationUtil(this.translateService);
    transUtil.initConfig();
  }

  toastMessageInit(){
    let messageObservable = this.toastState.$message()
    messageObservable.subscribe({
      next: message =>{ this.messageSerivce.create(message.type,message.text)}
    })
  }
}
