using CV.Contracts.Educations;

namespace CV.Application.Educations
{
    public interface IUpdateEducationService
    {
        Task<UpdateEducationResponse> UpdateAsync(Guid id, UpdateEducationRequest request);
    }
}
