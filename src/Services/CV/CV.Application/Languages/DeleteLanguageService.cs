using CV.Application.Abstractions.Persistence;
using CV.Contracts.Languages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Languages
{
    public class DeleteLanguageService : IDeleteLanguageService
    {
        private readonly ILanguageRepository _languageRepository;

        public DeleteLanguageService(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task<DeleteLanguageResponse> DeleteAsync(Guid id)
        {
            var language = await _languageRepository.GetByIdAsync(id);

            if (language == null)
                return null;

            await _languageRepository.DeleteAsync(language);

            return new DeleteLanguageResponse
            {
                Id = language.Id,
                IsDeleted = true
            };
        }
    }
}
