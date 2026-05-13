using AutoMapper;
using Blog.Application.Abstractions.Persistence;
using Blog.Application.Abstractions.Rules;
using Blog.Contracts.Comments;
using Blog.Domain.Entities;

namespace Blog.Application.Comments
{
    public class CreateCommentService : ICreateCommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IBlogReferenceValidationService _referenceValidationService;
        private readonly IMapper _mapper;

        public CreateCommentService(
            ICommentRepository commentRepository,
            IMapper mapper,
            IBlogReferenceValidationService referenceValidationService)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _referenceValidationService = referenceValidationService;
        }

        public async Task<CreateCommentResponse> CreateAsync(CreateCommentRequest request)
        {
            await _referenceValidationService.GetRequiredPostAsync(request.PostId);

            var comment = _mapper.Map<Comment>(request);
            comment.IsApproved = false;

            await _commentRepository.AddAsync(comment);

            return _mapper.Map<CreateCommentResponse>(comment);
        }
    }
}
