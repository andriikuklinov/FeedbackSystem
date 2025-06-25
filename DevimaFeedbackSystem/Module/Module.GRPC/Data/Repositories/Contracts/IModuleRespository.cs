using ModuleEntity = Module.GRPC.Data.Entities.Module;

namespace Module.GRPC.Data.Repositories.Contracts
{
    public interface IModuleRespository
    {
        Task<IEnumerable<ModuleEntity>> GetModules();
    }
}
