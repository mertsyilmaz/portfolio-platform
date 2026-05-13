using CV.Contracts.SocialLinks;

namespace CV.Application.SocialLinks
{
    public interface IGetSocialLinkByIdService
    {
        Task<GetSocialLinkByIdResponse> GetByIdAsync(Guid id);
    }
}
