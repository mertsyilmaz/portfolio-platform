using Blog.Application.Abstractions.Persistence;
using Blog.Application.Common.Exceptions;
using Blog.Contracts.Comments;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Comments
{
    public class DeleteCommentService : IDeleteCommentService
    {
        private readonly ICommentRepository _commentRepository;

        public DeleteCommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<DeleteCommentResponse> DeleteAsync(Guid id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);

            if (comment == null)
                throw new NotFoundException("Comment not found.");

            await _commentRepository.DeleteAsync(comment);

            return new DeleteCommentResponse
            {
                Id = id,
                IsDeleted = true
            };
        }
    }
}
