using AutoMapper;
using Blog.Application.Abstractions.Persistence;
using Blog.Contracts.Categories;

namespace Blog.Application.Categories
{
    public class GetCategoriesService : IGetCategoriesService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<GetCategoriesResponse>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();

            return _mapper.Map<List<GetCategoriesResponse>>(categories);
        }
    }
}
