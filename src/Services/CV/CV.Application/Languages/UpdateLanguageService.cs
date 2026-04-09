using CV.Application.Abstractions.Persistence;
using CV.Contracts.Languages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Languages
{
    public class UpdateLanguageService : IUpdateLanguageService
    {
        private readonly ILanguageRepository _languageRepository;

        public UpdateLanguageService(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task<UpdateLanguageResponse> UpdateAsync(Guid id, UpdateLanguageRequest request)
        {
            var language = await _languageRepository.GetByIdAsync(id);

            if (language == null)
                return null;

            language.Name = request.Name;
            language.Level = request.Level;

            await _languageRepository.UpdateAsync(language);

            return new UpdateLanguageResponse
            {
                Id = language.Id,
                Name = language.Name,
                Level = language.Level
            };
        }
    }
}
