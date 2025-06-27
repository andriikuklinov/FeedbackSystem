import { Component, inject } from "@angular/core";
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from "@angular/forms";
import { MatButtonModule } from "@angular/material/button";
import { MatDialog, MatDialogModule, MatDialogRef } from "@angular/material/dialog";

@Component({
    selector: 'feedback-create-dialog',
    templateUrl: './feedback-create-dialog.component.html',
    styleUrl: './feedback-create-dialog.component.css',
    imports: [MatButtonModule, MatDialogModule, ReactiveFormsModule]
})
export class FeedbackCreateDialog {
    dialogRef = inject(MatDialogRef<FeedbackCreateDialog>);
    form: FormGroup = new FormGroup({
        rating: new FormControl<string | null>(null, Validators.required),
        comment: new FormControl<string | null>('')
    });
    
    ratingOnChange($event: Event){
        debugger;
        const value = Number(($event.target as HTMLInputElement).value);
        if(value<3){
            this.form.get('comment')?.setValidators([Validators.required]);
        }
        else{
            this.form.get('comment')?.clearValidators();
        }
        this.form.get('comment')?.updateValueAndValidity();
    }
}