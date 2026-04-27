using AutoMapper;
using Blog.Application.Abstractions.Persistence;
using Blog.Application.Common.Exceptions;
using Blog.Contracts.Comments;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Comments
{
    public class UpdateCommentService : IUpdateCommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public UpdateCommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<UpdateCommentResponse> UpdateAsync(Guid id, UpdateCommentRequest request)
        {
            var comment = await _commentRepository.GetByIdAsync(id);

            if (comment == null)
                throw new NotFoundException("Comment not found.");

            _mapper.Map(request, comment);
            comment.UpdatedAt = DateTime.UtcNow;

            await _commentRepository.UpdateAsync(comment);

            return _mapper.Map<UpdateCommentResponse>(comment);
        }
    }
}
