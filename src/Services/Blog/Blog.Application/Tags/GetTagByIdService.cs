using Blog.Application.Abstractions.Persistence;
using Blog.Contracts.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Tags
{
    public class GetTagByIdService : IGetTagByIdService
    {
        private readonly ITagRepository _tagRepository;

        public GetTagByIdService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<GetTagsResponse?> GetByIdAsync(Guid id)
        {
            var tag = await _tagRepository.GetByIdAsync(id);

            if (tag == null)
                return null;

            return new GetTagsResponse
            {
                Id = tag.Id,
                Name = tag.Name
            };
        }
    }
}
