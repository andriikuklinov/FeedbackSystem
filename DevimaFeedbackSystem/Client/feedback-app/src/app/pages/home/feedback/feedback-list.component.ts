import { Component, OnInit, signal, WritableSignal } from "@angular/core";
import { FeedbackService } from "../../../common/services/feedback.service";
import { FeedbackModel } from "./models/feedback.model";
import { ActivatedRoute } from "@angular/router";

@Component({
    selector: 'feedback-list',
    templateUrl: './feedback-list.component.html',
    styleUrl: './feedback-list.component.css'
})
export class FeedbackListComponent implements OnInit{
    feedbacks: WritableSignal<FeedbackModel[]> = signal([])

    constructor(private feedbackService: FeedbackService, private route: ActivatedRoute){

    }

    ngOnInit(): void {
        this.loadFeedbacks(1);
        this.route.paramMap.subscribe((params)=>{
            this.loadFeedbacks(Number(params.get('moduleId')));
        });
    }

    private loadFeedbacks(moduleId: number){
        this.feedbackService.getFeedbacks(moduleId).subscribe((response)=>{
            debugger;
            this.feedbacks.set(response);
        });
    }
}