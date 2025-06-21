using AutoMapper;
using Feedback.API.Feedbacks.Commands;
using Feedback.API.Protos;
using Grpc.Core;
using MediatR;
using FeedbackEntity = Feedback.API.Data.Entities.Feedback;

namespace Feedback.API.Services
{
    public class FeedbackService: FeedbackProtoService.FeedbackProtoServiceBase
    {
        private readonly ILogger<FeedbackService> _logger;
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        public FeedbackService(IMapper mapper, ILogger<FeedbackService> logger, ISender sender)
        {
            _mapper = mapper;
            _logger = logger;
            _sender = sender;
        }

        public override async Task<FeedbackModel> CreateFeedback(CreateFeedbackRequest request, ServerCallContext context)
        {
            var command = _mapper.Map<CreateFeedbackCommand>(request);
            var result = await _sender.Send(command);
            var response = _mapper.Map<FeedbackModel>(result);

            return response;
        }
    }
}
