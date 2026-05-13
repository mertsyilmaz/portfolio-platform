using CV.Application.Abstractions.Persistence;
using CV.Application.Abstractions.Rules;
using CV.Application.Abstractions.Services;
using CV.Application.Common.Exceptions;
using CV.Domain.Entities;

namespace CV.Application.Common.Rules
{
    public class CvReferenceValidationService : ICvReferenceValidationService
    {
        private readonly IPersonalInfoRepository _personalInfoRepository;
        private readonly IFileService _fileService;

        public CvReferenceValidationService(IPersonalInfoRepository personalInfoRepository, IFileService fileService)
        {
            _personalInfoRepository = personalInfoRepository;
            _fileService = fileService;
        }

        public async Task ValidateProfileImageExistsAsync(Guid? profileImageId)
        {
            if (!profileImageId.HasValue)
                return;

            var fileExists = await _fileService.ExistsAsync(profileImageId.Value);
            Guard.AgainstInvalidReference(fileExists, ErrorMessages.ProfileImageNotFound);
        }

        public async Task EnsurePersonalInfoDoesNotExistAsync()
        {
            var personalInfo = await _personalInfoRepository.GetAsync();
            Guard.AgainstBusinessRule(personalInfo is not null, ErrorMessages.PersonalInfoAlreadyExists);
        }

        public async Task<PersonalInfo> GetRequiredPersonalInfoAsync()
        {
            var personalInfo = await _personalInfoRepository.GetAsync();
            Guard.AgainstNotFound(personalInfo, ErrorMessages.PersonalInfoNotFound);
            return personalInfo!;
        }
    }
}
