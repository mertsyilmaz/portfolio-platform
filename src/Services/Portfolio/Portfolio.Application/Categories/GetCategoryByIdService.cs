using AutoMapper;
using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Application.Common.Exceptions;
using Portfolio.Contracts.Categories;

namespace Portfolio.Application.Categories
{
    public class GetCategoryByIdService : IGetCategoryByIdService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryByIdService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<GetCategoryByIdResponse> GetByIdAsync(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(category, ErrorMessages.CategoryNotFound);
            return _mapper.Map<GetCategoryByIdResponse>(category);
        }
    }
}
