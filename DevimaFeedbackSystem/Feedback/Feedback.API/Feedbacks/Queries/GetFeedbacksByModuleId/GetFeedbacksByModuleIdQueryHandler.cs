using DevimaFeedbackSystem.Common.Core.CQRS;
using Feedback.API.Data.Repositories.Contracts;
using Feedback.API.Feedbacks.Queries.Common;

namespace Feedback.API.Feedbacks.Queries.GetFeedbacksByModuleId
{
    public class GetFeedbacksByModuleIdQueryHandler : IQueryHandler<GetFeedbacksByModuleIdQuery, GetFeedbacksResult>
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public GetFeedbacksByModuleIdQueryHandler(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task<GetFeedbacksResult> Handle(GetFeedbacksByModuleIdQuery query, CancellationToken cancellationToken)
        {
            var feedbacks = await _feedbackRepository.GetFeedbacksByModuleId(query.ModuleId, query.OrderByRating);
            return new GetFeedbacksResult(feedbacks);
        }
    }
}
