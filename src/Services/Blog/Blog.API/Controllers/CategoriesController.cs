using Blog.Application.Categories;
using Blog.Contracts.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICreateCategoryService _createCategoryService;
        private readonly IGetCategoriesService _getCategoriesService;
        private readonly IGetCategoryByIdService _getCategoryByIdService;
        private readonly IUpdateCategoryService _updateCategoryService;
        private readonly IDeleteCategoryService _deleteCategoryService;

        public CategoriesController(
            ICreateCategoryService createCategoryService,
            IGetCategoriesService getCategoriesService,
            IGetCategoryByIdService getCategoryByIdService,
            IUpdateCategoryService updateCategoryService,
            IDeleteCategoryService deleteCategoryService)
        {
            _createCategoryService = createCategoryService;
            _getCategoriesService = getCategoriesService;
            _getCategoryByIdService = getCategoryByIdService;
            _updateCategoryService = updateCategoryService;
            _deleteCategoryService = deleteCategoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryRequest request)
        {
            var result = await _createCategoryService.CreateAsync(request);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _getCategoriesService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _getCategoryByIdService.GetByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateCategoryRequest request)
        {
            var result = await _updateCategoryService.UpdateAsync(id, request);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _deleteCategoryService.DeleteAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
