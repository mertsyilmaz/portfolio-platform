using Blog.Application.Abstractions.Persistence;
using Blog.Contracts.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Categories
{
    public class GetCategoryByIdService : IGetCategoryByIdService
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryByIdService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<GetCategoriesResponse?> GetByIdAsync(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            if (category == null)
                return null;

            return new GetCategoriesResponse
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
