using CV.Contracts.Educations;

namespace CV.Application.Educations
{
    public interface IGetEducationByIdService
    {
        Task<GetEducationByIdResponse> GetByIdAsync(Guid id);
    }
}
