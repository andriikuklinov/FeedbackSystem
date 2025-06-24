using DevimaFeedbackSystem.Common.Core.DataAccess.Model;

namespace DevimaFeedbackSystem.Common.Core.DataAccess.Repository
{
    public interface IGenericRepository<T> where T: class, IEntity
    {
        IQueryable<T> GetAll();
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<int> RemoveAsync(T entity);
    }
}
