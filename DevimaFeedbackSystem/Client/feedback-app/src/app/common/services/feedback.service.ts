import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { map, Observable } from "rxjs";
import { FeedbackModel } from "../../pages/home/feedback/models/feedback.model";

@Injectable({
    providedIn: 'root'
})
export class FeedbackService {
    private httpClient: HttpClient = inject(HttpClient);
    
    constructor(){

    }

    getFeedbacks(moduleId: number): Observable<FeedbackModel[]>{
        let requestParams: HttpParams = new HttpParams()
            .set('moduleId', moduleId);
        return this.httpClient.get<FeedbackModel[]>('https://localhost:7282/Feedback/GetModuleFeedbacks',  { params: requestParams });;
    }
}