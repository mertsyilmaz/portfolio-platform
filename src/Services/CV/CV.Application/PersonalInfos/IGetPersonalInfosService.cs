using CV.Contracts.PersonalInfos;

namespace CV.Application.PersonalInfos
{
    public interface IGetPersonalInfosService
    {
        Task<GetPersonalInfoResponse> GetAsync();
    }
}
