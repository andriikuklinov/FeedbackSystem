import { Component } from "@angular/core";
import { ModuleListComponent } from "../../../pages/home/module/module-list.component";

@Component({
    selector: 'sidebar',
    templateUrl: './sidebar.component.html',
    styleUrl: './sidebar.component.css',
    imports: [ModuleListComponent]
})
export class SidebarComponent{
    
}