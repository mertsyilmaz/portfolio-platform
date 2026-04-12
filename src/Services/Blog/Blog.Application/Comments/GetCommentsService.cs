using Blog.Application.Abstractions.Persistence;
using Blog.Contracts.Comments;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Comments
{
    public class GetCommentsService : IGetCommentsService
    {
        private readonly ICommentRepository _commentRepository;

        public GetCommentsService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<List<GetCommentsResponse>> GetAllAsync()
        {
            var comments = await _commentRepository.GetAllAsync();

            return comments.Select(x => new GetCommentsResponse
            {
                Id = x.Id,
                PostId = x.PostId,
                AuthorId = x.AuthorId,
                Content = x.Content,
                IsApproved = x.IsApproved,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            }).ToList();
        }
    }
}
