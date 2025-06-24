using AutoMapper;
using Feedback.API.Data.Repositories;
using Feedback.API.Data.Repositories.Contracts;
using Feedback.API.Feedbacks.Queries.Common;
using Feedback.API.Feedbacks.Queries.GetFeedbacksByModuleId;
using Feedback.API.Feedbacks.Queries.GetUserFeedbacks;
using Feedback.API.Protos;
using Google.Protobuf;
using Google.Protobuf.Collections;
using FeedbackEntity = Feedback.API.Data.Entities.Feedback;

namespace Feedback.API.MappingProfile
{
    public class FeedbackMappingProfile: Profile
    {
        public FeedbackMappingProfile()
        {
            CreateMap<IFeedbackRepository, FeedbackRepository>();
            CreateMap<GetFeedbackByUserIdRequest, GetUserFeedbacksQuery>();
            CreateMap<GetFeedbacksResult, FeedbacksResponse>().ForMember(destination => destination.Feedbacks,
                source => source.MapFrom(feedback => feedback.Feedbacks));
            CreateMap<FeedbackEntity, FeedbackModel>()
                .ForMember(destination=>destination.Comment, source=>source.MapFrom(_=>_.Comment ?? string.Empty));
            CreateMap<GetFeedbacksByModuleIdRequest, GetFeedbacksByModuleIdQuery>();
        }
    }
}
