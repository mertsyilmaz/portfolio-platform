using Blog.Application.Abstractions.Persistence;
using Blog.Application.Common.Exceptions;

namespace Blog.Application.Posts
{
    public class DeletePostService : IDeletePostService
    {
        private readonly IPostRepository _postRepository;

        public DeletePostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task DeleteAsync(Guid id)
        {
            var post = await _postRepository.GetByIdAsync(id);

            Guard.AgainstNotFound(post, ErrorMessages.PostNotFound);

            await _postRepository.DeleteAsync(post);

        }
    }
}
