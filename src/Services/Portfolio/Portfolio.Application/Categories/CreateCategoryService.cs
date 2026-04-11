using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Contracts.Categories;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Categories
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
                Name = request.Name
            };
        }
    }
}
