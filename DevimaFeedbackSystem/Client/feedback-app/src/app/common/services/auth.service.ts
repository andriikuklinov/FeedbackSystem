import { inject, Injectable } from "@angular/core";
import { CookieService } from "ngx-cookie-service";
import { TokenResponse } from "./data/models/token-response.interface";
import { catchError, from, map, Observable, tap, throwError } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    private cookieService = inject(CookieService);
    private httpClient: HttpClient = inject(HttpClient);
    private router: Router = inject(Router);

    get token(): string {
        return this.cookieService.get('token');
    }

    get isAuth(): boolean {
        let token = this.cookieService.get('token');
        return typeof(token) !== undefined && (token.length > 0);
    }

    private setTokens(value: TokenResponse): void {
        debugger;
        this.cookieService.set('token', <string>value.access_token);
    }

    login(credentials: { login: string, password: string }): Observable<TokenResponse> {
        return this.httpClient.post<TokenResponse>('http://localhost:5135/Auth/Login', credentials).pipe(
            tap((value) => {
                debugger;
                this.setTokens(value);
            })
        );
    }

    logout() {
        this.cookieService.deleteAll();
        this.router.navigate(['/login'])
    }
}