import { Routes } from '@angular/router';
import { LayoutComponent } from './common/components/layout/layout.component';
import { LoginComponent } from './pages/login/login.component';
import { HomeComponent } from './pages/home/home.component';

export const routes: Routes = [
    {
        path: '', component: LayoutComponent, children: [
            { path: '', component: HomeComponent }
        ],
        //canActivate: [canActivateAuth]
    },
    { path: 'login', component: LoginComponent }
];
