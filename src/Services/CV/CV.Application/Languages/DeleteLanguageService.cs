using CV.Application.Abstractions.Persistence;
using CV.Application.Common.Exceptions;

namespace CV.Application.Languages
{
    public class DeleteLanguageService : IDeleteLanguageService
    {
        private readonly ILanguageRepository _languageRepository;

        public DeleteLanguageService(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task DeleteAsync(Guid id)
        {
            var language = await _languageRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(language, ErrorMessages.LanguageNotFound);
            await _languageRepository.DeleteAsync(language);
        }
    }
}
