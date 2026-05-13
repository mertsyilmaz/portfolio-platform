using CV.Application.Abstractions.Persistence;
using CV.Application.Common.Exceptions;

namespace CV.Application.SocialLinks
{
    public class DeleteSocialLinkService : IDeleteSocialLinkService
    {
        private readonly ISocialLinkRepository _socialLinkRepository;

        public DeleteSocialLinkService(ISocialLinkRepository socialLinkRepository)
        {
            _socialLinkRepository = socialLinkRepository;
        }

        public async Task DeleteAsync(Guid id)
        {
            var socialLink = await _socialLinkRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(socialLink, ErrorMessages.SocialLinkNotFound);
            await _socialLinkRepository.DeleteAsync(socialLink);
        }
    }
}
