using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Contracts.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Categories
{
    public class GetCategoryByIdService : IGetCategoryByIdService
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryByIdService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<GetCategoryByIdResponse?> GetByIdAsync(Guid id)
        {
            var category  = await _categoryRepository.GetByIdAsync(id);

            if (category == null) 
                return null;

            return new GetCategoryByIdResponse
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
