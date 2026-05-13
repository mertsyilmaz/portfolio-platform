using AutoMapper;
using CV.Application.Abstractions.Persistence;
using CV.Contracts.Languages;
using CV.Domain.Entities;

namespace CV.Application.Languages
{
    public class CreateLanguageService : ICreateLanguageService
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        public CreateLanguageService(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public async Task<CreateLanguageResponse> CreateAsync(CreateLanguageRequest request)
        {
            var language = _mapper.Map<Language>(request);
            await _languageRepository.AddAsync(language);
            return _mapper.Map<CreateLanguageResponse>(language);
        }
    }
}
