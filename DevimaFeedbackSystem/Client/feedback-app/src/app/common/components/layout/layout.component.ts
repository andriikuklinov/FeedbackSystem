import { Component, OnInit } from "@angular/core";
import { RouterOutlet } from "@angular/router";
import { SidebarComponent } from "../sidebar/sidebar.component";

@Component({
    selector: 'layout',
    imports: [RouterOutlet, SidebarComponent],
    templateUrl: './layout.component.html',
    styleUrl: './layout.component.css'
})
export class LayoutComponent implements OnInit{
    ngOnInit(){
        
    }
}