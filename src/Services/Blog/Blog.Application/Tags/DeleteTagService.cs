using Blog.Application.Abstractions.Persistence;
using Blog.Contracts.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Tags
{
    public class DeleteTagService : IDeleteTagService
    {
        private readonly ITagRepository _tagRepository;

        public DeleteTagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<DeleteTagResponse?> DeleteAsync(Guid id)
        {
            var tag = await _tagRepository.GetByIdAsync(id);

            if (tag == null)
                return null;

            await _tagRepository.DeleteAsync(tag);

            return new DeleteTagResponse
            {
                Id = id,
                IsDeleted = true
            };
        }
    }
}
