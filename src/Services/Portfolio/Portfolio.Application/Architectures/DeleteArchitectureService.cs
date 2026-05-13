using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Application.Common.Exceptions;

namespace Portfolio.Application.Architectures
{
    public class DeleteArchitectureService : IDeleteArchitectureService
    {
        private readonly IArchitectureRepository _architectureRepository;

        public DeleteArchitectureService(IArchitectureRepository architectureRepository)
        {
            _architectureRepository = architectureRepository;
        }

        public async Task DeleteAsync(Guid id)
        {
            var architecture = await _architectureRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(architecture, ErrorMessages.ArchitectureNotFound);

            await _architectureRepository.DeleteAsync(architecture);
        }
    }
}
