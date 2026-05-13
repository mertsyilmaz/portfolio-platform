using CV.Domain.Entities;

namespace CV.Application.Abstractions.Rules
{
    public interface ICvReferenceValidationService
    {
        Task ValidateProfileImageExistsAsync(Guid? profileImageId);

        Task EnsurePersonalInfoDoesNotExistAsync();

        Task<PersonalInfo> GetRequiredPersonalInfoAsync();
    }
}
