using Blog.Application.Abstractions.Persistence;
using Blog.Contracts.Comments;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Comments
{
    public class UpdateCommentService : IUpdateCommentService
    {
        private readonly ICommentRepository _commentRepository;

        public UpdateCommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<UpdateCommentResponse?> UpdateAsync(Guid id, UpdateCommentRequest request)
        {
            var comment = await _commentRepository.GetByIdAsync(id);

            if (comment == null)
                return null;

            comment.Content = request.Content;
            comment.UpdatedAt = DateTime.UtcNow;

            await _commentRepository.UpdateAsync(comment);

            return new UpdateCommentResponse
            {
                Id = comment.Id,
                PostId = comment.PostId,
                Content = comment.Content,
                IsApproved = comment.IsApproved,
                CreatedAt = comment.CreatedAt,
                UpdatedAt= comment.UpdatedAt
            };
        }
    }
}
