using CV.Application.Abstractions.Persistence;
using CV.Contracts.Languages;
using CV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Languages
{
    public class CreateLanguageService : ICreateLanguageService
    {
        private readonly ILanguageRepository _languageRepository;

        public CreateLanguageService(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task<CreateLanguageResponse> CreateAsync(CreateLanguageRequest request)
        {
            var language = new Language
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Level = request.Level,
                CreatedAt = DateTime.UtcNow
            };

            await _languageRepository.AddAsync(language);

            return new CreateLanguageResponse
            {
                Id = language.Id,
                Name = language.Name,
                Level = language.Level
            };
        }
    }
}
