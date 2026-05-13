using AutoMapper;
using CV.Application.Abstractions.Persistence;
using CV.Contracts.SocialLinks;
using CV.Domain.Entities;

namespace CV.Application.SocialLinks
{
    public class CreateSocialLinkService : ICreateSocialLinkService
    {
        private readonly ISocialLinkRepository _socialLinkRepository;
        private readonly IMapper _mapper;

        public CreateSocialLinkService(ISocialLinkRepository socialLinkRepository, IMapper mapper)
        {
            _socialLinkRepository = socialLinkRepository;
            _mapper = mapper;
        }

        public async Task<CreateSocialLinkResponse> CreateAsync(CreateSocialLinkRequest request)
        {
            var socialLink = _mapper.Map<SocialLink>(request);
            await _socialLinkRepository.AddAsync(socialLink);
            return _mapper.Map<CreateSocialLinkResponse>(socialLink);
        }
    }
}
