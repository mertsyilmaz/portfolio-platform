using AutoMapper;
using Blog.Application.Abstractions.Persistence;
using Blog.Application.Common.Exceptions;
using Blog.Contracts.Comments;

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

            Guard.AgainstNotFound(comment, ErrorMessages.CommentNotFound);

            return _mapper.Map<GetCommentsResponse>(comment);
        }
    }
}
