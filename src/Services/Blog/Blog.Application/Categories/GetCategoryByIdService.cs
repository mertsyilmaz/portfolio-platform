using AutoMapper;
using Blog.Application.Abstractions.Persistence;
using Blog.Application.Common.Exceptions;
using Blog.Contracts.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Categories
{
    public class GetCategoryByIdService : IGetCategoryByIdService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryByIdService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<GetCategoriesResponse> GetByIdAsync(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            if (category == null)
                throw new NotFoundException("Category not found.");

            return _mapper.Map<GetCategoriesResponse>(category);
        }
    }
}
