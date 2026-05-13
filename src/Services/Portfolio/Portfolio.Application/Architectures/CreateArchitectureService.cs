using AutoMapper;
using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Contracts.Architectures;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Architectures
{
    public class CreateArchitectureService : ICreateArchitectureService
    {
        private readonly IArchitectureRepository _architectureRepository;
        private readonly IMapper _mapper;

        public CreateArchitectureService(IArchitectureRepository architectureRepository, IMapper mapper)
        {
            _architectureRepository = architectureRepository;
            _mapper = mapper;
        }

        public async Task<CreateArchitectureResponse> CreateAsync(CreateArchitectureRequest request)
        {
            var architecture = _mapper.Map<Architecture>(request);
            await _architectureRepository.AddAsync(architecture);
            return _mapper.Map<CreateArchitectureResponse>(architecture);
        }
    }
}
