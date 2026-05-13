namespace CV.Application.SocialLinks
{
    public interface IDeleteSocialLinkService
    {
        Task DeleteAsync(Guid id);
    }
}
