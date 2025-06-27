import { Routes } from '@angular/router';
import { LayoutComponent } from './common/components/layout/layout.component';
import { LoginComponent } from './pages/login/login.component';
import { HomeComponent } from './pages/home/home.component';
import { canActivateAuth } from './common/guards/auth.guard';

export const routes: Routes = [
    {
        path: '', component: LayoutComponent, children: [
            { path: '', redirectTo: 'module/1', pathMatch: 'full'},
            { path: 'module/:moduleId', component: HomeComponent }
        ],
        canActivate: [canActivateAuth]
    },
    { path: 'login', component: LoginComponent }
];
