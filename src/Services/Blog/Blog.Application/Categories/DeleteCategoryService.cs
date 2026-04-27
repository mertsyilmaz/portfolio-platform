using Blog.Application.Abstractions.Persistence;
using Blog.Application.Common.Exceptions;
using Blog.Contracts.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Categories
{
    public class DeleteCategoryService : IDeleteCategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<DeleteCategoryResponse> DeleteAsync(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            if (category == null)
                throw new NotFoundException("Category not found.");

            await _categoryRepository.DeleteAsync(category);

            return new DeleteCategoryResponse
            {
                Id = id,
                IsDeleted = true
            };
        }
    }
}
