import { Component, OnInit, signal, WritableSignal } from "@angular/core";
import { FeedbackService } from "../../../common/services/feedback.service";
import { FeedbackModel } from "./models/feedback.model";

@Component({
    selector: 'feedback-list',
    templateUrl: './feedback-list.component.html',
    styleUrl: './feedback-list.component.css'
})
export class FeedbackListComponent implements OnInit{
    feedbacks: WritableSignal<FeedbackModel[]> = signal([])

    constructor(private feedbackService: FeedbackService){

    }

    ngOnInit(): void {
        this.feedbackService.getFeedbacks(1).subscribe((response)=>{
            debugger;
            this.feedbacks.set(response);
        });
    }
}