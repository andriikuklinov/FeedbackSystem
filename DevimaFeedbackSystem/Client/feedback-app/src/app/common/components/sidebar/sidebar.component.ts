import { Component } from "@angular/core";
import { ModuleListComponent } from "../../../pages/home/module/module-list.component";
import { Router } from "@angular/router";
import { AuthService } from "../../services/auth.service";

@Component({
    selector: 'sidebar',
    templateUrl: './sidebar.component.html',
    styleUrl: './sidebar.component.css',
    imports: [ModuleListComponent]
})
export class SidebarComponent{
    constructor(private authService: AuthService, private router: Router){

    }

    logout(): void{
        this.authService.logout();
    }
}