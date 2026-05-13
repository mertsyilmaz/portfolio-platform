using AutoMapper;
using Blog.Application.Abstractions.Persistence;
using Blog.Contracts.Comments;

namespace Blog.Application.Comments
{
    public class GetCommentsByPostIdService : IGetCommentsByPostIdService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public GetCommentsByPostIdService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<List<GetCommentsResponse>> GetByPostIdAsync(Guid postId)
        {
            var comments = await _commentRepository.GetByPostIdAsync(postId);

            return _mapper.Map<List<GetCommentsResponse>>(comments);
        }
    }
}
