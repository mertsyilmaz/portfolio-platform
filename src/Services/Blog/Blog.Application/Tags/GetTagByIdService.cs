using AutoMapper;
using Blog.Application.Abstractions.Persistence;
using Blog.Application.Common.Exceptions;
using Blog.Contracts.Tags;

namespace Blog.Application.Tags
{
    public class GetTagByIdService : IGetTagByIdService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public GetTagByIdService(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<GetTagsResponse> GetByIdAsync(Guid id)
        {
            var tag = await _tagRepository.GetByIdAsync(id);

            Guard.AgainstNotFound(tag, ErrorMessages.TagNotFound);

            return _mapper.Map<GetTagsResponse>(tag);
        }
    }
}
