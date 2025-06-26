import { Routes } from '@angular/router';
import { LayoutComponent } from './common/components/layout/layout.component';
import { LoginComponent } from './pages/login/login.component';

export const routes: Routes = [
    {
        path: '', component: LayoutComponent, children: [
            
        ],
        //canActivate: [canActivateAuth]
    },
    { path: 'login', component: LoginComponent }
];
