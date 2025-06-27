import { Component, inject, OnInit, signal, WritableSignal } from "@angular/core";
import { FeedbackService } from "../../../common/services/feedback.service";
import { FeedbackModel } from "./models/feedback.model";
import { ActivatedRoute } from "@angular/router";
import { MatDialog, MatDialogModule } from "@angular/material/dialog";
import { FeedbackCreateDialog } from "./components/feedback-create-dialog/feedback-create-dialog.component";
import { MatButtonModule } from "@angular/material/button";

@Component({
    selector: 'feedback-list',
    templateUrl: './feedback-list.component.html',
    styleUrl: './feedback-list.component.css',
    imports: [MatButtonModule, MatDialogModule]
})
export class FeedbackListComponent implements OnInit{
    feedbacks: WritableSignal<FeedbackModel[]> = signal([])
    moduleId: WritableSignal<number> = signal<number>(1);
    dialog = inject(MatDialog);
    constructor(private feedbackService: FeedbackService, private route: ActivatedRoute){

    }

    ngOnInit(): void {
        this.loadFeedbacks(1);
        this.route.paramMap.subscribe((params)=>{
            this.loadFeedbacks(Number(params.get('moduleId')));
            this.moduleId.set(Number(params.get('moduleId')));
        });
    }

    private loadFeedbacks(moduleId: number){
        this.feedbackService.getFeedbacks(moduleId).subscribe((response)=>{
            debugger;
            this.feedbacks.set(response);
        });
    }

    addFeedback(){
        const dialogRef = this.dialog.open(FeedbackCreateDialog, {
            width: '800px',
            data: null
        });

        dialogRef.afterClosed().subscribe(result => {
            console.log(result);
        });
    }
}