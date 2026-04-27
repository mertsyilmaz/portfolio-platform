using AutoMapper;
using Blog.Application.Abstractions.Persistence;
using Blog.Application.Common.Exceptions;
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
        private readonly IMapper _mapper;

        public CreateCommentService(
            ICommentRepository commentRepository,
            IPostRepository postRepository,
            IMapper mapper)
        {
            _commentRepository = commentRepository;
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<CreateCommentResponse> CreateAsync(CreateCommentRequest request)
        {
            var post = await _postRepository.GetByIdAsync(request.PostId);

            if (post == null)
                throw new NotFoundException("Post not found.");

            var comment = _mapper.Map<Comment>(request);
            comment.IsApproved = false;
            comment.CreatedAt = DateTime.UtcNow;

            await _commentRepository.AddAsync(comment);

            return _mapper.Map<CreateCommentResponse>(comment);
        }
    }
}
