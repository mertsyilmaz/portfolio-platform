using AutoMapper;
using Blog.Application.Abstractions.Persistence;
using Blog.Application.Common.Exceptions;
using Blog.Contracts.Categories;
using Blog.Contracts.Comments;
using Blog.Contracts.Images;
using Blog.Contracts.Posts;
using Blog.Contracts.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Posts
{
    public class GetPostByIdService : IGetPostByIdService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetPostByIdService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<GetPostByIdResponse> GetByIdAsync(Guid id)
        {
            var post = await _postRepository.GetByIdAsync(id);

            if (post == null)
                throw new NotFoundException("Post not found");

            return _mapper.Map<GetPostByIdResponse>(post);
        }
    }
}
