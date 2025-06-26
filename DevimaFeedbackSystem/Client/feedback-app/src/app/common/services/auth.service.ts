import { inject, Injectable } from "@angular/core";
import { CookieService } from "ngx-cookie-service";
import { TokenResponse } from "./data/models/token-response.interface";
import { catchError, from, Observable, tap, throwError } from "rxjs";
import { HttpClient } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    public token: string | null = null;
    public refreshToken: string | null = null;
    private cookieService = inject(CookieService);
    private httpClient: HttpClient = inject(HttpClient);

    get isAuth(): boolean {
        if (!this.token) {
            this.token = this.cookieService.get('token');
            this.refreshToken = this.cookieService.get('refreshToken')
        }
        return !!this.token;
    }

    private setTokens(value: TokenResponse): void {
        this.token = value.access_token;

        this.cookieService.set('token', <string>this.token);
    }

    login(credentials: { login: string, password: string }): Observable<TokenResponse> {
        return this.httpClient.post<TokenResponse>('https://localhost:7282/Auth/Login', credentials).pipe(
            tap((value) => {
                this.setTokens(value);
            })
        );
    }

    logout() {
        this.cookieService.deleteAll();
        this.token = null;
        this.refreshToken = null;
    }
}