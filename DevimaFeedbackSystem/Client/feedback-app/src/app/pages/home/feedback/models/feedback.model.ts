export interface FeedbackModel{
    id: number;
    comment: string;
    publishDate: { nanos: number, seconds: number};
    rating: number;
    moduleId: number;
    userId: number;
}