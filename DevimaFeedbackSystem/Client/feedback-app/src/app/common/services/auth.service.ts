import { inject, Injectable } from "@angular/core";
import { CookieService } from "ngx-cookie-service";
import { TokenResponse } from "./data/models/token-response.interface";
import { catchError, from, Observable, tap, throwError } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    public token: string | null = null;
    public refreshToken: string | null = null;
    private cookieService = inject(CookieService);

    get isAuth(): boolean {
        if (!this.token) {
            this.token = this.cookieService.get('token');
            this.refreshToken = this.cookieService.get('refreshToken')
        }
        return !!this.token;
    }

    private setTokens(value: TokenResponse): void {
        this.token = value.token;
        this.refreshToken = value.refreshToken;

        this.cookieService.set('token', <string>this.token);
        this.cookieService.set('refreshToken', <string>this.refreshToken);
    }

    login(credentials: { login: string, password: string }): Observable<TokenResponse> {
        return from<Promise<TokenResponse>>(new Promise(resolve => resolve({ token: 'a23c34sVBBNV23nshdg21mMbH', refreshToken: 'jd3fh18eu34bc35232bnTfRGBv' })))
            .pipe(
                tap(value => {
                    this.setTokens(value);
                })
            )
    }

    logout() {
        this.cookieService.deleteAll();
        this.token = null;
        this.refreshToken = null;
    }
}