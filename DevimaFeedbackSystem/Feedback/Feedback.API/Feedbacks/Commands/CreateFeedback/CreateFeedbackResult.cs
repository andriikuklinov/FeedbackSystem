using FeedbackEntity = Feedback.API.Data.Entities.Feedback;

namespace Feedback.API.Feedbacks.Commands.CreateFeedback
{
    public class CreateFeedbackResult
    {
        public FeedbackEntity Feedback { get; private set; }

        public CreateFeedbackResult(FeedbackEntity feedback)
        {
            Feedback = feedback;
        }
    }
}
