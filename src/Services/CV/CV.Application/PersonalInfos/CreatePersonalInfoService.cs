using AutoMapper;
using CV.Application.Abstractions.Persistence;
using CV.Application.Abstractions.Rules;
using CV.Contracts.PersonalInfos;
using CV.Domain.Entities;

namespace CV.Application.PersonalInfos
{
    public class CreatePersonalInfoService : ICreatePersonalInfoService
    {
        private readonly IPersonalInfoRepository _repository;
        private readonly ICvReferenceValidationService _referenceValidationService;
        private readonly IMapper _mapper;

        public CreatePersonalInfoService(
            IPersonalInfoRepository personalInfoRepository,
            ICvReferenceValidationService referenceValidationService,
            IMapper mapper)
        {
            _repository = personalInfoRepository;
            _referenceValidationService = referenceValidationService;
            _mapper = mapper;
        }

        public async Task<CreatePersonalInfoResponse> CreateAsync(CreatePersonalInfoRequest request)
        {
            await _referenceValidationService.EnsurePersonalInfoDoesNotExistAsync();
            await _referenceValidationService.ValidateProfileImageExistsAsync(request.ProfileImageId);

            var entity = _mapper.Map<PersonalInfo>(request);
            await _repository.AddAsync(entity);

            return _mapper.Map<CreatePersonalInfoResponse>(entity);
        }
    }
}
