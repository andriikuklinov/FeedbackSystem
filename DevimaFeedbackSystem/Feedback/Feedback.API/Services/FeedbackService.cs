using AutoMapper;
using Feedback.API.Feedbacks.Commands.CreateFeedback;
using Feedback.API.Feedbacks.Commands.RemoveFeedback;
using Feedback.API.Feedbacks.Queries.GetFeedbacksByModuleId;
using Feedback.API.Feedbacks.Queries.GetUserFeedbacks;
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

        public override async Task<FeedbacksResponse> GetFeedbacksByModuleId(GetFeedbacksByModuleIdRequest request, ServerCallContext context)
        {
            var query = _mapper.Map<GetFeedbacksByModuleIdQuery>(request);
            var result = await _sender.Send(query);
            var response = _mapper.Map<FeedbacksResponse>(result);

            return response;
        }

        public override async Task<FeedbacksResponse> GetFeedbacksByUserId(GetFeedbackByUserIdRequest request, ServerCallContext context)
        {
            var query = _mapper.Map<GetUserFeedbacksQuery>(request);
            var result = await _sender.Send(query);
            var response = _mapper.Map<FeedbacksResponse>(result);

            return response;
        }

        public override async Task<RemoveFeedbackResponse> RemoveFeedback(FeedbackModel request, ServerCallContext context)
        {
            var command = _mapper.Map<RemoveFeedbackCommand>(request);
            var result = await _sender.Send(command);
            var response = _mapper.Map<RemoveFeedbackResponse>(result);

            return response;
        }
    }
}
