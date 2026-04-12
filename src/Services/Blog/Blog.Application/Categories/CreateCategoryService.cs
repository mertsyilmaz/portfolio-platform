using AutoMapper;
using Blog.Application.Abstractions.Persistence;
using Blog.Contracts.Categories;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Categories
{
    public class CreateCategoryService : ICreateCategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CreateCategoryResponse> CreateAsync(CreateCategoryRequest request)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };

            await _categoryRepository.AddAsync(category);

            return _mapper.Map<CreateCategoryResponse>(category);
        }
    }
}
