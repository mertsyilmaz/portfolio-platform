using AutoMapper;
using CV.Application.Abstractions.Persistence;
using CV.Application.Abstractions.Rules;
using CV.Contracts.PersonalInfos;

namespace CV.Application.PersonalInfos
{
    public class UpdatePersonalInfoService : IUpdatePersonalInfoService
    {
        private readonly IPersonalInfoRepository _repository;
        private readonly ICvReferenceValidationService _referenceValidationService;
        private readonly IMapper _mapper;

        public UpdatePersonalInfoService(
            IPersonalInfoRepository repository,
            ICvReferenceValidationService referenceValidationService,
            IMapper mapper)
        {
            _repository = repository;
            _referenceValidationService = referenceValidationService;
            _mapper = mapper;
        }

        public async Task<UpdatePersonalInfoResponse> UpdateAsync(UpdatePersonalInfoRequest request)
        {
            var entity = await _referenceValidationService.GetRequiredPersonalInfoAsync();
            await _referenceValidationService.ValidateProfileImageExistsAsync(request.ProfileImageId);

            _mapper.Map(request, entity);
            await _repository.UpdateAsync(entity);

            return _mapper.Map<UpdatePersonalInfoResponse>(entity);
        }
    }
}
