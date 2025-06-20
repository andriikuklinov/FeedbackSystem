using DevimaFeedbackSystem.Common.Core.DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace DevimaFeedbackSystem.Common.Core.DataAccess.Repository
{
    public class GenericRepository<T, TContext> : IGenericRepository<T> where T: class, IEntity where TContext: DbContext
    {
        protected TContext context;
        public GenericRepository(TContext context)
        {
            this.context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<int> RemoveAsync(T entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();

            return entity;
        }
    }
}
