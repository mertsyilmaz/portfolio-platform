using AutoMapper;
using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Contracts.Architectures;

namespace Portfolio.Application.Architectures
{
    public class GetArchitecturesService : IGetArchitecturesService
    {
        private readonly IArchitectureRepository _architectureRepository;
        private readonly IMapper _mapper;

        public GetArchitecturesService(IArchitectureRepository architectureRepository, IMapper mapper)
        {
            _architectureRepository = architectureRepository;
            _mapper = mapper;
        }

        public async Task<List<GetArchitecturesResponse>> GetAllAsync()
        {
            var architectures = await _architectureRepository.GetAllAsync();
            return _mapper.Map<List<GetArchitecturesResponse>>(architectures);
        }
    }
}
