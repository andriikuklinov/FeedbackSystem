import { Component, inject, signal } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { AuthService } from "../../common/services/auth.service";

@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    styleUrl: './login.component.css'
})
export class LoginComponent{
    router: Router = inject(Router);
    authService: AuthService = inject(AuthService);
    form: FormGroup = new FormGroup({
        username: new FormControl<string | null>(null, Validators.required),
        password: new FormControl<string | null>(null, Validators.required)
    });
    isPasswordVisible = signal<boolean>(false);

    public onSubmit(event: Event): void{
        this.authService.login(this.form.value).subscribe((response)=>{
            if(response)
                this.router.navigate(['']);
        });
    }
}