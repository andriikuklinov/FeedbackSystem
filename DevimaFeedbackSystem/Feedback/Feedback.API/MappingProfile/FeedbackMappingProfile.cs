using AutoMapper;
using Feedback.API.Data.Repositories;
using Feedback.API.Data.Repositories.Contracts;
using Feedback.API.Extensions.Mapping;
using Feedback.API.Feedbacks.Commands.CreateFeedback;
using Feedback.API.Feedbacks.Queries.Common;
using Feedback.API.Feedbacks.Queries.GetFeedbacksByModuleId;
using Feedback.API.Feedbacks.Queries.GetUserFeedbacks;
using Feedback.API.Protos;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
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
                .ForMember(destination => destination.Comment, source => source.MapFrom(_ => _.Comment ?? string.Empty))
                .ForMember(destination => destination.PublishDate, options => options.MapFrom(source => Timestamp.FromDateTime(source.PublishDate.ToUniversalTime())));

            CreateMap<GetFeedbacksByModuleIdRequest, GetFeedbacksByModuleIdQuery>();

            CreateMap<CreateFeedbackRequest, CreateFeedbackCommand>()
                .ForMember(destination => destination.Id, options => options.MapFrom(source => source.Feedback.Id))
                .ForMember(destination => destination.Comment, options => options.MapFrom(source => source.Feedback.Comment))
                .ForMember(destination => destination.ModuleId, options => options.MapFrom(source => source.Feedback.ModuleId))
                .ForMember(destination => destination.UserId, options => options.MapFrom(source => source.Feedback.UserId))
                .ForMember(destination => destination.Rating, options => options.MapFrom(source => source.Feedback.Rating));

            CreateMap<CreateFeedbackCommand, FeedbackEntity>();
            CreateMap<CreateFeedbackResult, FeedbackModel>()
                .ForMember(destination => destination.Id, options => options.MapFrom(source => source.Feedback.Id))
                .ForMember(destination => destination.Comment, options => options.MapFrom(source => source.Feedback.Comment))
                .ForMember(destination => destination.ModuleId, options => options.MapFrom(source => source.Feedback.ModuleId))
                .ForMember(destination => destination.UserId, options => options.MapFrom(source => source.Feedback.UserId))
                .ForMember(destination => destination.Rating, options => options.MapFrom(source => source.Feedback.Rating))
                .ForMember(destination => destination.PublishDate, options => options.MapFrom(source => Timestamp.FromDateTime(source.Feedback.PublishDate.ToUniversalTime())));
        }
    }
}
