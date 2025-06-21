using AutoMapper;
using Feedback.API.Data.Entities;
using Feedback.API.Protos;

namespace Feedback.API.Services
{
    public class FeedbackService: FeedbackProtoService.FeedbackProtoServiceBase
    {
        private readonly ILogger<FeedbackService> _logger;
        private readonly IMapper _mapper;
        private readonly IFeedbackService
    }
}
