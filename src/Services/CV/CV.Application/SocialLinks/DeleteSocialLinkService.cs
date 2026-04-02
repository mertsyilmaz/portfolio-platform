using CV.Application.Abstractions.Persistence;
using CV.Contracts.SocialLinks;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.Application.SocialLinks
{
    public class DeleteSocialLinkService : IDeleteSocialLinkService
    {
        private readonly ISocialLinkRepository _repository;

        public DeleteSocialLinkService(ISocialLinkRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteSocialLinkResponse?> DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity is null)
                return null;

            await _repository.DeleteAsync(entity);

            return new DeleteSocialLinkResponse
            {
                Id = id,
                IsDeleted = true
            };
        }
    }
}
