using AutoMapper;
using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Contracts.Technologies;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Technologies
{
    public class CreateTechnologyService : ICreateTechnologyService
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IMapper _mapper;

        public CreateTechnologyService(ITechnologyRepository technologyRepository, IMapper mapper)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
        }

        public async Task<CreateTechnologyResponse> CreateAsync(CreateTechnologyRequest request)
        {
            var technology = _mapper.Map<Technology>(request);
            await _technologyRepository.AddAsync(technology);
            return _mapper.Map<CreateTechnologyResponse>(technology);
        }
    }
}
