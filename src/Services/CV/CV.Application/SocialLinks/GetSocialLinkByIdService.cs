using AutoMapper;
using CV.Application.Abstractions.Persistence;
using CV.Application.Common.Exceptions;
using CV.Contracts.SocialLinks;

namespace CV.Application.SocialLinks
{
    public class GetSocialLinkByIdService : IGetSocialLinkByIdService
    {
        private readonly ISocialLinkRepository _socialLinkRepository;
        private readonly IMapper _mapper;

        public GetSocialLinkByIdService(ISocialLinkRepository socialLinkRepository, IMapper mapper)
        {
            _socialLinkRepository = socialLinkRepository;
            _mapper = mapper;
        }

        public async Task<GetSocialLinkByIdResponse> GetByIdAsync(Guid id)
        {
            var socialLink = await _socialLinkRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(socialLink, ErrorMessages.SocialLinkNotFound);
            return _mapper.Map<GetSocialLinkByIdResponse>(socialLink);
        }
    }
}
