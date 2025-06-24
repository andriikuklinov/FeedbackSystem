using AutoMapper;
using DevimaFeedbackSystem.Common.Core.CQRS;
using Feedback.API.Data.Repositories.Contracts;
using Feedback.API.Feedbacks.Queries.Common;

namespace Feedback.API.Feedbacks.Queries.GetUserFeedbacks
{
    public class GetUserFeedbacksQueryHandler : IQueryHandler<GetUserFeedbacksQuery, GetFeedbacksResult>
    {
        private IFeedbackRepository _feedbackRepository;

        public GetUserFeedbacksQueryHandler(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }
        public async Task<GetFeedbacksResult> Handle(GetUserFeedbacksQuery query, CancellationToken cancellationToken)
        {
            var result = await _feedbackRepository.GetUserFeedbacks(query.UserId);
            return new GetFeedbacksResult(result);
        }
    }
}
