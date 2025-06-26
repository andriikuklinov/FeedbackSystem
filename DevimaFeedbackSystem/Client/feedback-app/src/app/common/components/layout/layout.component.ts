import { Component, OnInit } from "@angular/core";
import { RouterOutlet } from "@angular/router";

@Component({
    selector: 'layout',
    imports: [RouterOutlet],
    templateUrl: './layout.component.html',
    styleUrl: './layout.component.css'
})
export class LayoutComponent implements OnInit{
    ngOnInit(){
        
    }
}