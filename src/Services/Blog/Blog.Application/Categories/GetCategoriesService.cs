using Blog.Application.Abstractions.Persistence;
using Blog.Contracts.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Categories
{
    public class GetCategoriesService : IGetCategoriesService
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoriesService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<GetCategoriesResponse>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();

            return categories.Select(x => new GetCategoriesResponse
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
