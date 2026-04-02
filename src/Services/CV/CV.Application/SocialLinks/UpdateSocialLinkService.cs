using CV.Application.Abstractions.Persistence;
using CV.Contracts.SocialLinks;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.SocialLinks
{
    public class UpdateSocialLinkService : IUpdateSocialLinkService
    {
        private readonly ISocialLinkRepository _repository;

        public UpdateSocialLinkService(ISocialLinkRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateSocialLinkResponse?> UpdateAsync(Guid id, UpdateSocialLinkRequest request)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity is null)
                return null;

            entity.Platform = request.Platform;
            entity.Url = request.Url;
            entity.DisplayOrder = request.DisplayOrder;

            await _repository.UpdateAsync(entity);

            return new UpdateSocialLinkResponse
            {
                Id = entity.Id,
                Platform = entity.Platform,
                Url = entity.Url,
                DisplayOrder = entity.DisplayOrder
            };
        }
    }
}
