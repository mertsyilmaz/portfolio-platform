using Blog.Application.Abstractions.Persistence;
using Blog.Contracts.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Categories
{
    public class UpdateCategoryService : IUpdateCategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<UpdateCategoryResponse?> UpdateAsync(Guid id, UpdateCategoryRequest request)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            if (category == null)
                return null;

            category.Name = request.Name;

            await _categoryRepository.UpdateAsync(category);

            return new UpdateCategoryResponse
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
