using AutoMapper;
using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Contracts.Categories;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Categories
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
            var category = _mapper.Map<Category>(request);
            await _categoryRepository.AddAsync(category);
            return _mapper.Map<CreateCategoryResponse>(category);
        }
    }
}
