using CV.Contracts.Educations;

namespace CV.Application.Educations
{
    public interface ICreateEducationService
    {
        Task<CreateEducationResponse> CreateAsync(CreateEducationRequest request);
    }
}
