using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Application.Common.Exceptions;

namespace Portfolio.Application.Technologies
{
    public class DeleteTechnologyService : IDeleteTechnologyService
    {
        private readonly ITechnologyRepository _technologyRepository;

        public DeleteTechnologyService(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }

        public async Task DeleteAsync(Guid id)
        {
            var technology = await _technologyRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(technology, ErrorMessages.TechnologyNotFound);

            await _technologyRepository.DeleteAsync(technology);
        }
    }
}
