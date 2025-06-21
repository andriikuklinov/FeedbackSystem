using AutoMapper;
using DevimaFeedbackSystem.Common.Core.CQRS;
using Feedback.API.Data.Repositories.Contracts;
using FeedbackEntity = Feedback.API.Data.Entities.Feedback;

namespace Feedback.API.Feedbacks.Commands
{
    public class CreateFeedbackCommandHandler: ICommandHandler<CreateFeedbackCommand, CreateFeedbackResult>
    {
        private readonly IMapper _mapper;
        private readonly IFeedbackRepository _feedbackRepository;

        public CreateFeedbackCommandHandler(IMapper mapper, IFeedbackRepository feedbackRepository)
        {
            _mapper = mapper;
            _feedbackRepository = feedbackRepository;
        }

        public async Task<CreateFeedbackResult> Handle(CreateFeedbackCommand command, CancellationToken cancellationToken)
        {
            var feedback = await _feedbackRepository.CreateFeedback(_mapper.Map<FeedbackEntity>(command))
                ?? throw new NullReferenceException("Create feedback operation returns null.");
            return _mapper.Map<CreateFeedbackResult>(feedback);
        }
    }
}
