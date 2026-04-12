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

        public CreateCategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CreateCategoryResponse> CreateAsync(CreateCategoryRequest request)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };

            await _categoryRepository.AddAsync(category);

            return new CreateCategoryResponse
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
