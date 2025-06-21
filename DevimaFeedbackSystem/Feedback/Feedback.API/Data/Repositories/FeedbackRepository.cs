using DevimaFeedbackSystem.Common.Core.DataAccess.Repository;
using FeedbackEntity = Feedback.API.Data.Entities.Feedback;

namespace Feedback.API.Data.Repositories
{
    public class FeedbackRepository: GenericRepository<FeedbackEntity, FeedbackContext>
    {
        public FeedbackRepository(FeedbackContext context):base(context)
        {
            
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
