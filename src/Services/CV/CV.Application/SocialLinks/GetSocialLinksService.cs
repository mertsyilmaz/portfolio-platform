using CV.Application.Abstractions.Persistence;
using CV.Contracts.SocialLinks;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.SocialLinks
{
    public class GetSocialLinksService : IGetSocialLinksService
    {
        private readonly ISocialLinkRepository _repository;

        public GetSocialLinksService(ISocialLinkRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetSocialLinksResponse>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();

            return entities.Select(x => new GetSocialLinksResponse
            {
                Id = x.Id,
                Platform = x.Platform,
                Url = x.Url,
                DisplayOrder = x.DisplayOrder
            }).ToList();
        }
    }
}
