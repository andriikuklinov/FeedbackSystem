import { Component, OnInit, signal, WritableSignal } from "@angular/core";
import { FeedbackListComponent } from "./feedback/feedback-list.component";
import { ActivatedRoute } from "@angular/router";

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrl: './home.component.css',
    imports: [FeedbackListComponent]
})
export class HomeComponent implements OnInit{
    moduleId: WritableSignal<number> = signal<number>(1);
    constructor(private route: ActivatedRoute){

    }

    ngOnInit(){
        this.route.paramMap.subscribe((value)=>{
            this.moduleId.set(Number(value.get('moduleId')));
        });
    }

    addFeedback(){
        
    }
}