using AutoMapper;
using Blog.Application.Abstractions.Persistence;
using Blog.Application.Common.Exceptions;
using Blog.Contracts.Tags;
using System;
using System.Collections.Generic;
using System.Text;

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

            if (tag == null)
                throw new NotFoundException("Tag not found.");

            return _mapper.Map<GetTagsResponse>(tag);
        }
    }
}
