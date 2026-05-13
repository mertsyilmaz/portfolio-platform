using AutoMapper;
using Blog.Application.Abstractions.Persistence;
using Blog.Application.Common.Exceptions;
using Blog.Contracts.Comments;

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

            Guard.AgainstNotFound(comment, ErrorMessages.CommentNotFound);

            _mapper.Map(request, comment);

            await _commentRepository.UpdateAsync(comment);

            return _mapper.Map<UpdateCommentResponse>(comment);
        }
    }
}
