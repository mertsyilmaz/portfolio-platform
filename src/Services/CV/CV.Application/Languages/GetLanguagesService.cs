using CV.Application.Abstractions.Persistence;
using CV.Contracts.Languages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Languages
{
    public class GetLanguagesService : IGetLanguagesService
    {
        private readonly ILanguageRepository _languageRepository;

        public GetLanguagesService(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task<List<GetLanguagesResponse>> GetAllAsync()
        {
            var languages = await _languageRepository.GetAllAsync();

            return languages.Select(x => new GetLanguagesResponse { 
                Id = x.Id,
                Name = x.Name,
                Level = x.Level
            }).ToList();
        }
    }
}
