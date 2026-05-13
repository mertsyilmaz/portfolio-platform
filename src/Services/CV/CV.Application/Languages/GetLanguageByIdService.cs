using AutoMapper;
using CV.Application.Abstractions.Persistence;
using CV.Application.Common.Exceptions;
using CV.Contracts.Languages;

namespace CV.Application.Languages
{
    public class GetLanguageByIdService : IGetLanguageByIdService
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        public GetLanguageByIdService(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public async Task<GetLanguageByIdResponse> GetByIdAsync(Guid id)
        {
            var language = await _languageRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(language, ErrorMessages.LanguageNotFound);
            return _mapper.Map<GetLanguageByIdResponse>(language);
        }
    }
}
