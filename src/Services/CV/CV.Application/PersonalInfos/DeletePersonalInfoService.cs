using CV.Application.Abstractions.Persistence;
using CV.Application.Abstractions.Rules;

namespace CV.Application.PersonalInfos
{
    public class DeletePersonalInfoService : IDeletePersonalInfoService
    {
        private readonly IPersonalInfoRepository _repository;
        private readonly ICvReferenceValidationService _referenceValidationService;

        public DeletePersonalInfoService(IPersonalInfoRepository repository, ICvReferenceValidationService referenceValidationService)
        {
            _repository = repository;
            _referenceValidationService = referenceValidationService;
        }

        public async Task DeleteAsync()
        {
            var entity = await _referenceValidationService.GetRequiredPersonalInfoAsync();
            await _repository.DeleteAsync(entity);
        }
    }
}
