using Blog.Application.Abstractions.Persistence;
using Blog.Contracts.Comments;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Comments
{
    public class GetCommentByIdService : IGetCommentByIdService
    {
        private readonly ICommentRepository _commentRepository;

        public GetCommentByIdService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<GetCommentsResponse?> GetByIdAsync(Guid id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);

            if (comment == null)
                return null;

            return new GetCommentsResponse
            {
                Id = comment.Id,
                PostId = comment.PostId,
                AuthorId = comment.AuthorId,
                Content = comment.Content,
                IsApproved = comment.IsApproved,
                CreatedAt = comment.CreatedAt,
                UpdatedAt = comment.UpdatedAt
            };
        }
    }
}
