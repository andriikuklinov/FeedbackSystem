using DevimaFeedbackSystem.Common.Core.CQRS;
using FeedbackEntity = Feedback.API.Data.Entities.Feedback;

namespace Feedback.API.Feedbacks.Commands.RemoveFeedback
{
    public class RemoveFeedbackCommand: FeedbackEntity, ICommand<int>
    {
    }
}
