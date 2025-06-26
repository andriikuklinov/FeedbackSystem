import { Component } from "@angular/core";
import { FeedbackListComponent } from "./feedback/feedback-list.component";

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrl: './home.component.css',
    imports: [FeedbackListComponent]
})
export class HomeComponent{
    
}