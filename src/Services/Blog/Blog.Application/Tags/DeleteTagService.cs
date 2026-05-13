using Blog.Application.Abstractions.Persistence;
using Blog.Application.Common.Exceptions;

namespace Blog.Application.Tags
{
    public class DeleteTagService : IDeleteTagService
    {
        private readonly ITagRepository _tagRepository;

        public DeleteTagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task DeleteAsync(Guid id)
        {
            var tag = await _tagRepository.GetByIdAsync(id);

            Guard.AgainstNotFound(tag, ErrorMessages.TagNotFound);

            await _tagRepository.DeleteAsync(tag);

        }
    }
}
