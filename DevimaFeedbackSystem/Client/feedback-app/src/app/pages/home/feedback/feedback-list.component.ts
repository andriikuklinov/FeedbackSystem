import { Component, inject, OnInit, signal, WritableSignal } from "@angular/core";
import { FeedbackService } from "../../../common/services/feedback.service";
import { ActivatedRoute } from "@angular/router";
import { MatDialog, MatDialogModule } from "@angular/material/dialog";
import { FeedbackCreateDialog } from "./components/feedback-create-dialog/feedback-create-dialog.component";
import { MatButtonModule } from "@angular/material/button";
import { FeedbackModel } from "./models/feedback.model";
import { DatePipe, NgClass } from "@angular/common";
import { SvgIconComponent } from "../../../common/components/svg-icon/svg-icon.component";

@Component({
    selector: 'feedback-list',
    templateUrl: './feedback-list.component.html',
    styleUrl: './feedback-list.component.css',
    imports: [MatButtonModule, MatDialogModule, DatePipe, SvgIconComponent, NgClass]
})
export class FeedbackListComponent implements OnInit{
    feedbacks: WritableSignal<FeedbackModel[]> = signal([])
    moduleId: WritableSignal<number> = signal<number>(1);
    dialog = inject(MatDialog);
    orderByRating = signal('asc');
    constructor(private feedbackService: FeedbackService, private route: ActivatedRoute){

    }

    ngOnInit(): void {
        this.loadFeedbacks(1, this.orderByRating());
        this.route.paramMap.subscribe((params)=>{
            this.loadFeedbacks(Number(params.get('moduleId')), this.orderByRating());
            this.moduleId.set(Number(params.get('moduleId')));
        });
    }

    private loadFeedbacks(moduleId: number, orderByRating: string){
        this.feedbackService.getFeedbacks(moduleId, orderByRating).subscribe((response)=>{
            this.feedbacks.set(response);
        });
    }

    addFeedback(){
        const dialogRef = this.dialog.open(FeedbackCreateDialog, {
            width: '800px',
            data: null
        });

        dialogRef.afterClosed().subscribe((feedback: FeedbackModel) => {
            feedback.moduleId = this.moduleId();
            this.feedbackService.createFeedback(feedback).subscribe((response)=>{
                if(response){
                    this.feedbacks.update(values=> [...values, response]);
                }
            });
        });
    }

    removeFeedback(feedback: FeedbackModel){
        debugger;
        if(feedback){
            this.feedbackService.removeFeedback(feedback).subscribe((response)=>{
                if(response){
                    this.feedbacks.update(values=> [...values.filter((value)=> value.id != feedback.id)]);
                }
            })
        }
    }

    orderFeedbacks(){
        debugger;
        this.orderByRating.update(value=> value=='asc' ? 'desc' : 'asc');
        this.loadFeedbacks(this.moduleId(), this.orderByRating());
    }
}