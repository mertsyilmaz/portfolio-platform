using AutoMapper;
using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Application.Common.Exceptions;
using Portfolio.Contracts.Technologies;

namespace Portfolio.Application.Technologies
{
    public class GetTechnologyByIdService : IGetTechnologyByIdService
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IMapper _mapper;

        public GetTechnologyByIdService(ITechnologyRepository technologyRepository, IMapper mapper)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
        }

        public async Task<GetTechnologyByIdResponse> GetByIdAsync(Guid id)
        {
            var technology = await _technologyRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(technology, ErrorMessages.TechnologyNotFound);
            return _mapper.Map<GetTechnologyByIdResponse>(technology);
        }
    }
}
