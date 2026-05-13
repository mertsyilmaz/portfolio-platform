using AutoMapper;
using Blog.Application.Abstractions.Persistence;
using Blog.Contracts.Tags;
using Blog.Domain.Entities;

namespace Blog.Application.Tags
{
    public class CreateTagService : ICreateTagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public CreateTagService(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<CreateTagResponse> CreateAsync(CreateTagRequest request)
        {
            var tag = _mapper.Map<Tag>(request);

            await _tagRepository.AddAsync(tag);

            return _mapper.Map<CreateTagResponse>(tag);
        }
    }
}
