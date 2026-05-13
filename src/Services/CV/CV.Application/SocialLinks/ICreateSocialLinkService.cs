using CV.Contracts.SocialLinks;

namespace CV.Application.SocialLinks
{
    public interface ICreateSocialLinkService
    {
        Task<CreateSocialLinkResponse> CreateAsync(CreateSocialLinkRequest request);
    }
}
