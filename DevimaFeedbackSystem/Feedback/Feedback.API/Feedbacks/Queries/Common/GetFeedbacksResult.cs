using FeedbackEntity = Feedback.API.Data.Entities.Feedback;

namespace Feedback.API.Feedbacks.Queries.Common
{
    public class GetFeedbacksResult
    {
        public IEnumerable<FeedbackEntity> Feedbacks { get; private set; }

        public GetFeedbacksResult(IEnumerable<FeedbackEntity> feedbacks)
        {
            Feedbacks = feedbacks;
        }
    }
}
