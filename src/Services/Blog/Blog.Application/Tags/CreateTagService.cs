using Blog.Application.Abstractions.Persistence;
using Blog.Contracts.Tags;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Tags
{
    public class CreateTagService : ICreateTagService
    {
        private readonly ITagRepository _tagRepository;

        public CreateTagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<CreateTagResponse> CreateAsync(CreateTagRequest request)
        {
            var tag = new Tag
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };

            await _tagRepository.AddAsync(tag);

            return new CreateTagResponse
            {
                Id = tag.Id,
                Name = tag.Name
            };
        }
    }
}
