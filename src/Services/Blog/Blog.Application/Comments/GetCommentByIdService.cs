using AutoMapper;
using Blog.Application.Abstractions.Persistence;
using Blog.Application.Common.Exceptions;
using Blog.Contracts.Comments;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Comments
{
    public class GetCommentByIdService : IGetCommentByIdService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public GetCommentByIdService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<GetCommentsResponse> GetByIdAsync(Guid id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);

            if (comment == null)
                throw new NotFoundException("Comment not found.");

            return _mapper.Map<GetCommentsResponse>(comment);
        }
    }
}
