using AutoMapper;
using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Application.Common.Exceptions;
using Portfolio.Contracts.Architectures;

namespace Portfolio.Application.Architectures
{
    public class UpdateArchitectureService : IUpdateArchitectureService
    {
        private readonly IArchitectureRepository _architectureRepository;
        private readonly IMapper _mapper;

        public UpdateArchitectureService(IArchitectureRepository architectureRepository, IMapper mapper)
        {
            _architectureRepository = architectureRepository;
            _mapper = mapper;
        }

        public async Task<UpdateArchitectureResponse> UpdateAsync(Guid id, UpdateArchitectureRequest request)
        {
            var architecture = await _architectureRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(architecture, ErrorMessages.ArchitectureNotFound);

            _mapper.Map(request, architecture);
            await _architectureRepository.UpdateAsync(architecture);

            return _mapper.Map<UpdateArchitectureResponse>(architecture);
        }
    }
}
