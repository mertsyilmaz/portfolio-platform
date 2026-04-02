using CV.Application.Abstractions.Persistence;
using CV.Contracts.SocialLinks;
using CV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.SocialLinks
{
    public class CreateSocialLinkService : ICreateSocialLinkService
    {
        private readonly ISocialLinkRepository _repository;

        public CreateSocialLinkService(ISocialLinkRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateSocialLinkResponse> CreateAsync(CreateSocialLinkRequest request)
        {
            var entity = new SocialLink
            {
                Id = Guid.NewGuid(),
                Platform = request.Platform,
                Url = request.Url,
                DisplayOrder = request.DisplayOrder,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(entity);

            return new CreateSocialLinkResponse
            {
                Id = entity.Id,
                Platform = entity.Platform,
                Url = entity.Url
            };
        }
    }
}
