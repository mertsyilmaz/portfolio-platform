using AutoMapper;
using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Application.Common.Exceptions;
using Portfolio.Contracts.Architectures;

namespace Portfolio.Application.Architectures
{
    public class GetArchitectureByIdService : IGetArchitectureByIdService
    {
        private readonly IArchitectureRepository _architectureRepository;
        private readonly IMapper _mapper;

        public GetArchitectureByIdService(IArchitectureRepository architectureRepository, IMapper mapper)
        {
            _architectureRepository = architectureRepository;
            _mapper = mapper;
        }

        public async Task<GetArchitectureByIdResponse> GetByIdAsync(Guid id)
        {
            var architecture = await _architectureRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(architecture, ErrorMessages.ArchitectureNotFound);
            return _mapper.Map<GetArchitectureByIdResponse>(architecture);
        }
    }
}
