using DevimaFeedbackSystem.Common.Core.CQRS;
using Feedback.API.Feedbacks.Queries.Common;

namespace Feedback.API.Feedbacks.Queries.GetUserFeedbacks
{
    public class GetUserFeedbacksQuery: IQuery<GetFeedbacksResult>
    {
        public int UserId { get; private set; }

        public GetUserFeedbacksQuery(int userId)
        {
            UserId = userId;
        }
    }
}
