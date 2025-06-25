using AutoMapper;
using Module.GRPC.Modules.Queries.GetModules;
using Module.GRPC.Protos;
using ModuleEntity = Module.GRPC.Data.Entities.Module;

namespace Module.GRPC.MappingProfile
{
    public class ModuleMappingProfile: Profile
    {
        public ModuleMappingProfile()
        {
            CreateMap<ModuleEntity, ModuleModel>();
            CreateMap<GetModulesResult, ModulesResponse>().ForMember(destination => destination.Modules, options => options.MapFrom(source => source.Modules));
        }
    }
}
