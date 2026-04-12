using Blog.Application.Abstractions.Persistence;
using Blog.Contracts.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Tags
{
    public class GetTagsService : IGetTagsService
    {
        private readonly ITagRepository _tagRepository;

        public GetTagsService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<List<GetTagsResponse>> GetAllAsync()
        {
            var tags = await _tagRepository.GetAllAsync();

            return tags.Select(x => new GetTagsResponse
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
