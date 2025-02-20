import { Injectable } from '@angular/core';
import { BehaviorSubject, Subject } from 'rxjs';
import { message } from '../../models/entities/message';

@Injectable({
  providedIn: 'root'
})
export class ToastStateService {

  private  messageSubject = new Subject<message>();

    $message(){
        return this.messageSubject.asObservable()
    }

    addError(text: string) {
        this.messageSubject.next({ type: 'error', text });
    }
}
