import { HttpHandlerFn, HttpInterceptorFn, HttpRequest } from "@angular/common/http";
import { inject } from "@angular/core";
import { catchError, switchMap, throwError } from "rxjs";
import { AuthService } from "../services/auth.service";
import { CookieService } from "ngx-cookie-service";

export const authTokenInterceptor: HttpInterceptorFn = (request, next) => {
    const authService: AuthService = inject(AuthService);
    const token: string | null = authService.token;
    
    if (!token)
        return next(request);

    request = request.clone({
        setHeaders: {
            Authorization: `Bearer ${token}`
        }
    });

    return next(addToken(request, token)).pipe(
        catchError(error => {
            if(error.status == 401){
                authService.logout();
            }
            return throwError(error);
        })
    )
}

const addToken = (request: HttpRequest<any>, token: string | null) => {
    return request.clone({
        setHeaders: {
            Authorization: `Bearer ${token}`
        }
    });
}