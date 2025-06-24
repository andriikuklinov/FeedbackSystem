using AutoMapper;
using DevimaFeedbackSystem.Common.Core.CQRS;
using Feedback.API.Data.Repositories.Contracts;
using FeedbackEntity = Feedback.API.Data.Entities.Feedback;

namespace Feedback.API.Feedbacks.Commands.RemoveFeedback
{
    public class RemoveFeedbackCommandHandler : ICommandHandler<RemoveFeedbackCommand, int>
    {
        private IMapper _mapper;
        private IFeedbackRepository _feedbackRepository;

        public RemoveFeedbackCommandHandler(IMapper mapper, IFeedbackRepository feedbackRepository)
        {
            _mapper = mapper;
            _feedbackRepository = feedbackRepository;
        }
        public async Task<int> Handle(RemoveFeedbackCommand command, CancellationToken cancellationToken)
        {
            var feedback = _mapper.Map<FeedbackEntity>(command);
            var result = await _feedbackRepository.DeleteFeedback(feedback);

            return result;
        }
    }
}
