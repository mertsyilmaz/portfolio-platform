using CV.Contracts.Educations;

namespace CV.Application.Educations
{
    public interface IGetEducationsService
    {
        Task<List<GetEducationsResponse>> GetAllAsync();
    }
}
