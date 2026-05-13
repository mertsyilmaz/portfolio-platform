using AutoMapper;
using CV.Application.Abstractions.Persistence;
using CV.Application.Common.Exceptions;
using CV.Contracts.SocialLinks;

namespace CV.Application.SocialLinks
{
    public class UpdateSocialLinkService : IUpdateSocialLinkService
    {
        private readonly ISocialLinkRepository _socialLinkRepository;
        private readonly IMapper _mapper;

        public UpdateSocialLinkService(ISocialLinkRepository socialLinkRepository, IMapper mapper)
        {
            _socialLinkRepository = socialLinkRepository;
            _mapper = mapper;
        }

        public async Task<UpdateSocialLinkResponse> UpdateAsync(Guid id, UpdateSocialLinkRequest request)
        {
            var socialLink = await _socialLinkRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(socialLink, ErrorMessages.SocialLinkNotFound);
            _mapper.Map(request, socialLink);
            await _socialLinkRepository.UpdateAsync(socialLink);
            return _mapper.Map<UpdateSocialLinkResponse>(socialLink);
        }
    }
}
