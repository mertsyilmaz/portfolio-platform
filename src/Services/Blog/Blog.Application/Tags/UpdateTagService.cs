using Blog.Application.Abstractions.Persistence;
using Blog.Contracts.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Tags
{
    public class UpdateTagService : IUpdateTagService
    {
        private readonly ITagRepository _tagRepository;

        public UpdateTagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<UpdateTagResponse?> UpdateAsync(Guid id, UpdateTagRequest request)
        {
            var tag = await _tagRepository.GetByIdAsync(id);

            if (tag == null)
                return null;

            tag.Name = request.Name;

            await _tagRepository.UpdateAsync(tag);

            return new UpdateTagResponse
            {
                Id = tag.Id,
                Name = tag.Name
            };
        }
    }
}
