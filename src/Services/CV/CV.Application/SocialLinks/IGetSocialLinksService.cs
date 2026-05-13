using CV.Contracts.SocialLinks;

namespace CV.Application.SocialLinks
{
    public interface IGetSocialLinksService
    {
        Task<List<GetSocialLinksResponse>> GetAllAsync();
    }
}
