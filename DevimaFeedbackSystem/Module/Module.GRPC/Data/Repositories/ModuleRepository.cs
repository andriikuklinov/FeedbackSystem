using DevimaFeedbackSystem.Common.Core.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Module.GRPC.Data.Repositories.Contracts;
using ModuleEntity = Module.GRPC.Data.Entities.Module;

namespace Module.GRPC.Data.Repositories
{
    public class ModuleRepository : GenericRepository<ModuleEntity, ModuleContext> , IModuleRespository
    {
        public ModuleRepository(ModuleContext context) : base(context)
        {

        }
        public async Task<IEnumerable<ModuleEntity>> GetModules()
        {
            return await GetAll().ToListAsync();
        }
    }
}
