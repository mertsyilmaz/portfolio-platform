using CV.Contracts.PersonalInfos;

namespace CV.Application.PersonalInfos
{
    public interface IUpdatePersonalInfoService
    {
        Task<UpdatePersonalInfoResponse> UpdateAsync(UpdatePersonalInfoRequest request);
    }
}
