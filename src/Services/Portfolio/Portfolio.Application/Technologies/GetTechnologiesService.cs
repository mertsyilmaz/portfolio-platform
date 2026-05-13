using AutoMapper;
using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Contracts.Technologies;

namespace Portfolio.Application.Technologies
{
    public class GetTechnologiesService : IGetTechnologiesService
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IMapper _mapper;

        public GetTechnologiesService(ITechnologyRepository technologyRepository, IMapper mapper)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
        }

        public async Task<List<GetTechnologiesResponse>> GetAllAsync()
        {
            var technologies = await _technologyRepository.GetAllAsync();
            return _mapper.Map<List<GetTechnologiesResponse>>(technologies);
        }
    }
}
