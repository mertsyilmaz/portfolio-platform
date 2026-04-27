using AutoMapper;
using Blog.Application.Abstractions.Persistence;
using Blog.Application.Common.Exceptions;
using Blog.Contracts.Tags;
using System;
using System.Collections.Generic;
using System.Text;

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

            if (tag == null)
                throw new NotFoundException("Tag not found.");

            _mapper.Map(request, tag);

            await _tagRepository.UpdateAsync(tag);

            return _mapper.Map<UpdateTagResponse>(tag);
        }
    }
}
