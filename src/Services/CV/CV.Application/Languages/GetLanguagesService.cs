using AutoMapper;
using CV.Application.Abstractions.Persistence;
using CV.Contracts.Languages;

namespace CV.Application.Languages
{
    public class GetLanguagesService : IGetLanguagesService
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        public GetLanguagesService(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public async Task<List<GetLanguagesResponse>> GetAllAsync()
        {
            var languages = await _languageRepository.GetAllAsync();
            return _mapper.Map<List<GetLanguagesResponse>>(languages);
        }
    }
}
