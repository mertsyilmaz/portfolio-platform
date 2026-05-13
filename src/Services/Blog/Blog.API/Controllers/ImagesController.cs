using Blog.Application.Images;
using Blog.Contracts.Images;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ICreateImageService _createImageService;
        private readonly IGetImagesService _getImagesService;
        private readonly IGetImageByIdService _getImageByIdService;
        private readonly IGetImagesByPostIdService _getImagesByPostIdService;
        private readonly IUpdateImageService _updateImageService;
        private readonly IDeleteImageService _deleteImageService;

        public ImagesController(
            ICreateImageService createImageService,
            IGetImagesService getImagesService,
            IGetImageByIdService getImageByIdService,
            IGetImagesByPostIdService getImagesByPostIdService,
            IUpdateImageService updateImageService,
            IDeleteImageService deleteImageService)
        {
            _createImageService = createImageService;
            _getImagesService = getImagesService;
            _getImageByIdService = getImageByIdService;
            _getImagesByPostIdService = getImagesByPostIdService;
            _updateImageService = updateImageService;
            _deleteImageService = deleteImageService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateImageRequest request)
        {
            var result = await _createImageService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _getImagesService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _getImageByIdService.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpGet("post/{postId:guid}")]
        public async Task<IActionResult> GetByPostId(Guid postId)
        {
            var result = await _getImagesByPostIdService.GetByPostIdAsync(postId);
            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateImageRequest request)
        {
            var result = await _updateImageService.UpdateAsync(id, request);

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _deleteImageService.DeleteAsync(id);

            return NoContent();
        }
    }
}
