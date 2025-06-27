using DevimaFeedbackSystem.Common.Core.CQRS;
using Feedback.API.Feedbacks.Queries.Common;
using Feedback.API.Protos;

namespace Feedback.API.Feedbacks.Queries.GetFeedbacksByModuleId
{
    public class GetFeedbacksByModuleIdQuery: IQuery<GetFeedbacksResult>
    {
        public int ModuleId { get; private set; }
        public string OrderByRating { get; private set; }

        public GetFeedbacksByModuleIdQuery(int moduleId, string orderByRating)
        {
            ModuleId = moduleId;
            OrderByRating = orderByRating;
        }
    }
}
