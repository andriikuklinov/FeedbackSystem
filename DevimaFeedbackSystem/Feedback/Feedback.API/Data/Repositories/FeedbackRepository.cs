using DevimaFeedbackSystem.Common.Core.DataAccess.Repository;
using Feedback.API.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using FeedbackEntity = Feedback.API.Data.Entities.Feedback;

namespace Feedback.API.Data.Repositories
{
    public class FeedbackRepository: GenericRepository<FeedbackEntity, FeedbackContext>, IFeedbackRepository
    {
        public FeedbackRepository(FeedbackContext context):base(context)
        {
            
        }
        public async Task<IEnumerable<FeedbackEntity>> GetUserFeedbacks(int userId)
        {
            var feedbacks = await GetAll().Where(_ => _.UserId == userId).ToListAsync();
            return feedbacks;
        }
        public async Task<IEnumerable<FeedbackEntity>> GetFeedbacksByModuleId(int moduleId, string orderByRating)
        {
            var feedbacks = GetAll().Where(_ => _.ModuleId == moduleId);
            if (orderByRating == "asc")
                feedbacks = feedbacks.OrderBy(_ => _.Rating);
            else
                feedbacks = feedbacks.OrderByDescending(_ => _.Rating);
            return await feedbacks.ToListAsync();
        }

        public async Task<Entities.Feedback> CreateFeedback(Entities.Feedback feedback)
        {
            var result = await AddAsync(feedback);
            return result;
        }

        public async Task<int> DeleteFeedback(Entities.Feedback feedback)
        {
            int feedbackId = await RemoveAsync(feedback);
            return feedbackId;
        }

        public async Task<Entities.Feedback> UpdateFeedback(Entities.Feedback feedback)
        {
            var result = await UpdateAsync(feedback);
            return result;
        }
    }
}
