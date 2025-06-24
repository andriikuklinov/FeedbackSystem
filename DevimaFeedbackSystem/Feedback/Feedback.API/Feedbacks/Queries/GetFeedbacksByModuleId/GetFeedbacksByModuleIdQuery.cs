using DevimaFeedbackSystem.Common.Core.CQRS;
using Feedback.API.Feedbacks.Queries.Common;
using Feedback.API.Protos;

namespace Feedback.API.Feedbacks.Queries.GetFeedbacksByModuleId
{
    public class GetFeedbacksByModuleIdQuery: IQuery<GetFeedbacksResult>
    {
        public int ModuleId { get; private set; }

        public GetFeedbacksByModuleIdQuery(int moduleId)
        {
            ModuleId = moduleId;
        }
    }
}
