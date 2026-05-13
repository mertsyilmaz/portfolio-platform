using Blog.Application.Abstractions.Persistence;
using Blog.Application.Common.Exceptions;

namespace Blog.Application.Categories
{
    public class DeleteCategoryService : IDeleteCategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task DeleteAsync(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            Guard.AgainstNotFound(category, ErrorMessages.CategoryNotFound);

            await _categoryRepository.DeleteAsync(category);

        }
    }
}
