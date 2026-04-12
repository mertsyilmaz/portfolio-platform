using Blog.Application.Abstractions.Persistence;
using Blog.Contracts.Comments;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Comments
{
    public class CreateCommentService : ICreateCommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IPostRepository _postRepository;

        public CreateCommentService(
            ICommentRepository commentRepository,
            IPostRepository postRepository)
        {
            _commentRepository = commentRepository;
            _postRepository = postRepository;
        }

        public async Task<CreateCommentResponse> CreateAsync(CreateCommentRequest request)
        {
            var post = await _postRepository.GetByIdAsync(request.PostId);

            if (post == null)
                throw new Exception("Post not found.");

            var comment = new Comment
            {
                Id = Guid.NewGuid(),
                PostId = request.PostId,
                AuthorId = request.AuthorId,
                Content = request.Content,
                IsApproved = false,
                CreatedAt = DateTime.UtcNow
            };

            await _commentRepository.AddAsync(comment);

            return new CreateCommentResponse
            {
                Id = comment.Id,
                PostId = comment.PostId,
                Content = comment.Content,
                IsApproved = comment.IsApproved,
                CreatedAt = comment.CreatedAt
            };
        }
    }
}
