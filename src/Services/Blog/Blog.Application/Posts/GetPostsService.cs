using AutoMapper;
using Blog.Application.Abstractions.Persistence;
using Blog.Contracts.Posts;

namespace Blog.Application.Posts
{
    public class GetPostsService : IGetPostsService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetPostsService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<List<GetPostsResponse>> GetAllAsync()
        {
            var posts = await _postRepository.GetAllAsync();

            return _mapper.Map<List<GetPostsResponse>>(posts);
        }
    }
}
