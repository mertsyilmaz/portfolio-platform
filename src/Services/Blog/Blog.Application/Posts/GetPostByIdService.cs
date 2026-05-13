using AutoMapper;
using Blog.Application.Abstractions.Persistence;
using Blog.Application.Common.Exceptions;
using Blog.Contracts.Posts;

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

            Guard.AgainstNotFound(post, ErrorMessages.PostNotFound);

            return _mapper.Map<GetPostByIdResponse>(post);
        }
    }
}
