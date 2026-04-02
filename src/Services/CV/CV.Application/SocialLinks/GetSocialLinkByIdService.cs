using CV.Application.Abstractions.Persistence;
using CV.Contracts.SocialLinks;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.SocialLinks
{
    public class GetSocialLinkByIdService : IGetSocialLinkByIdService
    {
        private readonly ISocialLinkRepository _repository;

        public GetSocialLinkByIdService(ISocialLinkRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetSocialLinkByIdResponse?> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity is null)
                return null;

            return new GetSocialLinkByIdResponse
            {
                Id = entity.Id,
                Platform = entity.Platform,
                Url = entity.Url,
                DisplayOrder = entity.DisplayOrder,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}
