using AutoMapper;
using CV.Application.Abstractions.Persistence;
using CV.Application.Common.Exceptions;
using CV.Contracts.Languages;

namespace CV.Application.Languages
{
    public class UpdateLanguageService : IUpdateLanguageService
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        public UpdateLanguageService(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public async Task<UpdateLanguageResponse> UpdateAsync(Guid id, UpdateLanguageRequest request)
        {
            var language = await _languageRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(language, ErrorMessages.LanguageNotFound);
            _mapper.Map(request, language);
            await _languageRepository.UpdateAsync(language);
            return _mapper.Map<UpdateLanguageResponse>(language);
        }
    }
}
