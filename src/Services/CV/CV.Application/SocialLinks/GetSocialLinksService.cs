using AutoMapper;
using CV.Application.Abstractions.Persistence;
using CV.Contracts.SocialLinks;

namespace CV.Application.SocialLinks
{
    public class GetSocialLinksService : IGetSocialLinksService
    {
        private readonly ISocialLinkRepository _socialLinkRepository;
        private readonly IMapper _mapper;

        public GetSocialLinksService(ISocialLinkRepository socialLinkRepository, IMapper mapper)
        {
            _socialLinkRepository = socialLinkRepository;
            _mapper = mapper;
        }

        public async Task<List<GetSocialLinksResponse>> GetAllAsync()
        {
            var socialLinks = await _socialLinkRepository.GetAllAsync();
            return _mapper.Map<List<GetSocialLinksResponse>>(socialLinks);
        }
    }
}
