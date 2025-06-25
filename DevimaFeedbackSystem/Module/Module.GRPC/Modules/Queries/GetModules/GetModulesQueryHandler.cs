using AutoMapper;
using DevimaFeedbackSystem.Common.Core.CQRS;
using Module.GRPC.Data.Repositories.Contracts;

namespace Module.GRPC.Modules.Queries.GetModules
{
    public class GetModulesQueryHandler: IQueryHandler<GetModulesQuery, GetModulesResult>
    {
        private readonly IModuleRespository _moduleRepository;
        private readonly IMapper _mapper;

        public GetModulesQueryHandler(IMapper mapper, IModuleRespository moduleRepository)
        {
            _mapper = mapper;
            _moduleRepository = moduleRepository;
        }

        public async Task<GetModulesResult> Handle(GetModulesQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<GetModulesResult>(await _moduleRepository.GetModules());
        }
    }
}
