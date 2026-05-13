using AutoMapper;
using Blog.Application.Abstractions.Persistence;
using Blog.Application.Common.Exceptions;
using Blog.Contracts.Tags;

namespace Blog.Application.Tags
{
    public class UpdateTagService : IUpdateTagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public UpdateTagService(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<UpdateTagResponse> UpdateAsync(Guid id, UpdateTagRequest request)
        {
            var tag = await _tagRepository.GetByIdAsync(id);

            Guard.AgainstNotFound(tag, ErrorMessages.TagNotFound);

            _mapper.Map(request, tag);

            await _tagRepository.UpdateAsync(tag);

            return _mapper.Map<UpdateTagResponse>(tag);
        }
    }
}
