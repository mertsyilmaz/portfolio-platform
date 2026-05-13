using CV.Contracts.PersonalInfos;

namespace CV.Application.PersonalInfos
{
    public interface ICreatePersonalInfoService
    {
        Task<CreatePersonalInfoResponse> CreateAsync(CreatePersonalInfoRequest request);
    }
}
