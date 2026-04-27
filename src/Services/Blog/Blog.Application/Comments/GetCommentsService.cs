using AutoMapper;
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
        private readonly IMapper _mapper;

        public GetCommentsService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<List<GetCommentsResponse>> GetAllAsync()
        {
            var comments = await _commentRepository.GetAllAsync();

            return _mapper.Map<List<GetCommentsResponse>>(comments);
        }
    }
}
