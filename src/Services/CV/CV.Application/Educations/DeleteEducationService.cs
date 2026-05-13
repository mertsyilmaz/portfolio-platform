using CV.Application.Abstractions.Persistence;
using CV.Application.Common.Exceptions;

namespace CV.Application.Educations
{
    public class DeleteEducationService : IDeleteEducationService
    {
        private readonly IEducationRepository _educationRepository;

        public DeleteEducationService(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }

        public async Task DeleteAsync(Guid id)
        {
            var education = await _educationRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(education, ErrorMessages.EducationNotFound);
            await _educationRepository.DeleteAsync(education);
        }
    }
}
