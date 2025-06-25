using ModuleEntity = Module.GRPC.Data.Entities.Module;

namespace Module.GRPC.Modules.Queries.GetModules
{
    public class GetModulesResult
    {
        public IEnumerable<ModuleEntity> Modules { get; private set; }

        public GetModulesResult(IEnumerable<ModuleEntity> modules)
        {
            Modules = modules;
        }
    }
}
