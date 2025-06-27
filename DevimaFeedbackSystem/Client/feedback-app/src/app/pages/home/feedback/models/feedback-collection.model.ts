import { FeedbackModel } from "./feedback.model";

export interface FeedbackCollection {
    feedbacks: FeedbackModel[],
    averageScore: number,
    count: number
}