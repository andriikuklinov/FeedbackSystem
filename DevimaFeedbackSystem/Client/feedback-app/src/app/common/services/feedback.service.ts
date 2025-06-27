import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { map, Observable } from "rxjs";
import { FeedbackModel } from "../../pages/home/feedback/models/feedback.model";
import { AuthService } from "./auth.service";
import { FeedbackCollection } from "../../pages/home/feedback/models/feedback-collection.model";

@Injectable({
    providedIn: 'root'
})
export class FeedbackService {
    private httpClient: HttpClient = inject(HttpClient);
    private authService: AuthService = inject(AuthService);
    constructor(){

    }
    private setCurrentUserId(){
        const token = this.authService.token;
        const payload = token.split('.')[1];
        const result = JSON.parse(atob(payload));
        debugger;
        return result?.sub;
    }
    getFeedbacks(moduleId: number, orderByRating: string): Observable<FeedbackCollection>{
        let requestParams: HttpParams = new HttpParams()
            .set('moduleId', moduleId)
            .set('orderByRating', orderByRating);
        return this.httpClient.get<FeedbackCollection>('https://localhost:7282/Feedback/GetModuleFeedbacks',  { params: requestParams });;
    }

    createFeedback(feedback: FeedbackModel): Observable<FeedbackModel>{
        feedback.userId=this.setCurrentUserId();
        return this.httpClient.post<FeedbackModel>('https://localhost:7282/Feedback/CreateFeedback', feedback);
    }

    removeFeedback(feedback: FeedbackModel): Observable<FeedbackModel>{
        debugger;
        return this.httpClient.post<FeedbackModel>('https://localhost:7282/Feedback/DeleteFeedback', { 
            id: feedback.id,
            comment: feedback.comment,
            userId: feedback.userId,
            rating: feedback.rating,
            moduleId: feedback.moduleId
        });
    }
}