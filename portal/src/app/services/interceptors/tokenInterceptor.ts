import { HttpEvent, HttpHandlerFn, HttpRequest } from "@angular/common/http";
import { Observable } from "rxjs";
import { authConstants } from "../../models/Constants/authConstants";

export function tokenInterceptor (req: HttpRequest<unknown>, next: HttpHandlerFn): Observable<HttpEvent<unknown>> {
    let token = localStorage.getItem(authConstants.AUTH_TOKEN);
    if(token !== null)
        req = req.clone(
        {
            headers: req.headers.set(authConstants.AUTH_HEADER, 'Bearer ' + token)
        }
    )
        
    return next(req);
  }