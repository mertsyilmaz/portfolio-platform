using Blog.Application.Abstractions.Persistence;
using Blog.Application.Common.Exceptions;

namespace Blog.Application.Comments
{
    public class DeleteCommentService : IDeleteCommentService
    {
        private readonly ICommentRepository _commentRepository;

        public DeleteCommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task DeleteAsync(Guid id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);

            Guard.AgainstNotFound(comment, ErrorMessages.CommentNotFound);

            await _commentRepository.DeleteAsync(comment);

        }
    }
}
