using CV.Contracts.SocialLinks;

namespace CV.Application.SocialLinks
{
    public interface IUpdateSocialLinkService
    {
        Task<UpdateSocialLinkResponse> UpdateAsync(Guid id, UpdateSocialLinkRequest request);
    }
}
