using FeedbackEntity = Feedback.API.Data.Entities.Feedback;

namespace Feedback.API.Feedbacks.Commands
{
    public class CreateFeedbackResult
    {
        public FeedbackEntity Feedback { get; private set; }

        public CreateFeedbackResult(FeedbackEntity feedback)
        {
            this.Feedback = feedback;
        }
    }
}
