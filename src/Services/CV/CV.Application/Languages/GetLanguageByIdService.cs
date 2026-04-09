using CV.Application.Abstractions.Persistence;
using CV.Contracts.Languages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.Languages
{
    public class GetLanguageByIdService : IGetLanguageByIdService
    {
        private readonly ILanguageRepository _languageRepository;

        public GetLanguageByIdService(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task<GetLanguageByIdResponse> GetByIdAsync(Guid id)
        {
            var language  = await _languageRepository.GetByIdAsync(id);

            if (language == null)
                return null;

            return new GetLanguageByIdResponse
            {
                Id = language.Id,
                Name = language.Name,
                Level = language.Level,
                CreatedAt = language.CreatedAt
            };
            
        }
    }
}
