using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using Module.GRPC.Modules.Queries.GetModules;
using Module.GRPC.Protos;

namespace Module.GRPC.Services
{
    public class ModuleService: ModuleProtoService.ModuleProtoServiceBase
    {
        private readonly ILogger<ModuleService> _logger;
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        public ModuleService(IMapper mapper, ILogger<ModuleService> logger, ISender sender)
        {
            _mapper = mapper;
            _logger = logger;
            _sender = sender;
        }
        public override async Task<ModulesResponse> GetModules(Empty request, ServerCallContext context)
        {
            var query = new GetModulesQuery();
            var result = await _sender.Send(query);
            var response = _mapper.Map<ModulesResponse>(result);

            return response;
        }
    }
}
