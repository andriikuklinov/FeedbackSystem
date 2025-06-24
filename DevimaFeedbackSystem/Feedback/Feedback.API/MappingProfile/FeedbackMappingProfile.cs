using AutoMapper;
using Feedback.API.Data.Repositories;
using Feedback.API.Data.Repositories.Contracts;

namespace Feedback.API.MappingProfile
{
    public class FeedbackMappingProfile: Profile
    {
        public FeedbackMappingProfile()
        {
            CreateMap<IFeedbackRepository, FeedbackRepository>();
        }
    }
}
