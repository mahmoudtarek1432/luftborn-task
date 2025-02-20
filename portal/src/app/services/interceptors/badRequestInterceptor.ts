import { HttpEvent, HttpEventType, HttpHandlerFn, HttpRequest } from "@angular/common/http";
import { inject } from "@angular/core";
import { Router } from "@angular/router";
import { empty, Observable, take, tap, throwError } from "rxjs";
import { authConstants } from "../../models/Constants/authConstants";
import { BaseResponse } from "../../models/DTOs/BaseResponse";
import { ToastStateService } from "../state/ToastState.service";

export function badRequestInterceptor(req: HttpRequest<unknown>, next: HttpHandlerFn): Observable<HttpEvent<unknown>> 
{
    const messageService = inject(ToastStateService);
    return next(req).pipe(tap(event => {
        if (event.type === HttpEventType.Response
          && (event.body as BaseResponse<unknown>).isSuccess === false
        ) {
            messageService.addError((event.body as BaseResponse<unknown>).message);
        }
    
    }))
}