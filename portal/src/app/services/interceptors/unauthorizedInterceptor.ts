import { HttpEvent, HttpEventType, HttpHandlerFn, HttpRequest } from "@angular/common/http";
import { inject } from "@angular/core";
import { Router } from "@angular/router";
import { Observable, tap } from "rxjs";
import { authConstants } from "../../models/Constants/authConstants";

export function unauthorizedInterceptor(req: HttpRequest<unknown>, next: HttpHandlerFn): Observable<HttpEvent<unknown>> 
{
    //usually we would refresh the token in this step, following the selected OAuth grant
    return next(req).pipe(tap(event => {
        if (event.type === HttpEventType.Response
          && event.status === 401
        ) {
            localStorage.removeItem(authConstants.AUTH_TOKEN)
            var router = inject(Router)
            router.navigateByUrl("/login")
        }
    }))
}