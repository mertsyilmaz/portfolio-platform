using Blog.Application.Tags;
using Blog.Contracts.Tags;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ICreateTagService _createTagService;
        private readonly IGetTagsService _getTagsService;
        private readonly IGetTagByIdService _getTagByIdService;
        private readonly IUpdateTagService _updateTagService;
        private readonly IDeleteTagService _deleteTagService;

        public TagsController(
            ICreateTagService createTagService,
            IGetTagsService getTagsService,
            IGetTagByIdService getTagByIdService,
            IUpdateTagService updateTagService,
            IDeleteTagService deleteTagService)
        {
            _createTagService = createTagService;
            _getTagsService = getTagsService;
            _getTagByIdService = getTagByIdService;
            _updateTagService = updateTagService;
            _deleteTagService = deleteTagService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTagRequest request)
        {
            var result = await _createTagService.CreateAsync(request);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _getTagsService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _getTagByIdService.GetByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateTagRequest request)
        {
            var result = await _updateTagService.UpdateAsync(id, request);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _deleteTagService.DeleteAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
