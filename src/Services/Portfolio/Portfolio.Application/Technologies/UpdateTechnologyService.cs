using AutoMapper;
using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Application.Common.Exceptions;
using Portfolio.Contracts.Technologies;

namespace Portfolio.Application.Technologies
{
    public class UpdateTechnologyService : IUpdateTechnologyService
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IMapper _mapper;

        public UpdateTechnologyService(ITechnologyRepository technologyRepository, IMapper mapper)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
        }

        public async Task<UpdateTechnologyResponse> UpdateAsync(Guid id, UpdateTechnologyRequest request)
        {
            var technology = await _technologyRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(technology, ErrorMessages.TechnologyNotFound);

            _mapper.Map(request, technology);
            await _technologyRepository.UpdateAsync(technology);

            return _mapper.Map<UpdateTechnologyResponse>(technology);
        }
    }
}
