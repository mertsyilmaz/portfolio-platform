using AutoMapper;
using CV.Application.Abstractions.Rules;
using CV.Contracts.PersonalInfos;

namespace CV.Application.PersonalInfos
{
    public class GetPersonalInfoService : IGetPersonalInfosService
    {
        private readonly ICvReferenceValidationService _referenceValidationService;
        private readonly IMapper _mapper;

        public GetPersonalInfoService(ICvReferenceValidationService referenceValidationService, IMapper mapper)
        {
            _referenceValidationService = referenceValidationService;
            _mapper = mapper;
        }

        public async Task<GetPersonalInfoResponse> GetAsync()
        {
            var entity = await _referenceValidationService.GetRequiredPersonalInfoAsync();
            return _mapper.Map<GetPersonalInfoResponse>(entity);
        }
    }
}
