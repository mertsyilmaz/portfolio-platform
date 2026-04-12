using Blog.Application.Abstractions.Persistence;
using Blog.Contracts.Comments;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Comments
{
    public class GetCommentsByPostIdService : IGetCommentsByPostIdService
    {
        private readonly ICommentRepository _commentRepository;

        public GetCommentsByPostIdService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<List<GetCommentsResponse>> GetByPostIdAsync(Guid postId)
        {
            var comments = await _commentRepository.GetByPostIdAsync(postId);

            return comments.Select(x => new GetCommentsResponse
            {
                Id = x.Id,
                PostId = x.PostId,
                AuthorId = x.AuthorId,
                Content = x.Content,
                IsApproved = x.IsApproved,
                CreatedAt = x.CreatedAt
            }).ToList();
        }
    }
}
