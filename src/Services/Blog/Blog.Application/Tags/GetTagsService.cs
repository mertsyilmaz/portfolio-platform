using AutoMapper;
using Blog.Application.Abstractions.Persistence;
using Blog.Contracts.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Tags
{
    public class GetTagsService : IGetTagsService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public GetTagsService(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<List<GetTagsResponse>> GetAllAsync()
        {
            var tags = await _tagRepository.GetAllAsync();

            return _mapper.Map<List<GetTagsResponse>>(tags);
        }
    }
}
