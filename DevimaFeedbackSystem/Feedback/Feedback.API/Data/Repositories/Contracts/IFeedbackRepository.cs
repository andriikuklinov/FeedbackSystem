using Feedback.API.Data.Entities;
using FeedbackEntity = Feedback.API.Data.Entities.Feedback;

namespace Feedback.API.Data.Repositories.Contracts
{
    public interface IFeedbackRepository
    {
        Task<IEnumerable<FeedbackEntity>> GetFeedbacksByModuleId(int moduleId);
        Task<IEnumerable<FeedbackEntity>> GetUserFeedbacks(int userId);
        Task<FeedbackEntity> CreateFeedback(FeedbackEntity feedback);
        Task<FeedbackEntity> UpdateFeedback(FeedbackEntity feedback);
        Task<int> DeleteFeedback(FeedbackEntity feedback);
    }
}
