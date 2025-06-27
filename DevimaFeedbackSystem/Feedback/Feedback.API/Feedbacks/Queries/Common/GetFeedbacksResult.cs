using FeedbackEntity = Feedback.API.Data.Entities.Feedback;

namespace Feedback.API.Feedbacks.Queries.Common
{
    public class GetFeedbacksResult
    {
        public IEnumerable<FeedbackEntity> Feedbacks { get; private set; }
        public double AverageScore { get; private set; }
        public int Count { get; private set; }
        public GetFeedbacksResult(IEnumerable<FeedbackEntity> feedbacks)
        {
            Feedbacks = feedbacks;
            AverageScore = feedbacks.Average(_=>_.Rating);
            Count = feedbacks.Count();
        }
    }
}
