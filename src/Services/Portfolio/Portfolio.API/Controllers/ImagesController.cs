using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Images;
using Portfolio.Contracts.Images;

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ICreateImageService _createImageService;
        private readonly IGetImagesService _getImagesService;
        private readonly IGetImageByIdService _getImageByIdService;
        private readonly IUpdateImageService _updateImageService;
        private readonly IDeleteImageService _deleteImageService;

        public ImagesController(
            ICreateImageService createImageService,
            IGetImagesService getImagesService,
            IGetImageByIdService getImageByIdService,
            IUpdateImageService updateImageService,
            IDeleteImageService deleteImageService)
        {
            _createImageService = createImageService;
            _getImagesService = getImagesService;
            _getImageByIdService = getImageByIdService;
            _updateImageService = updateImageService;
            _deleteImageService = deleteImageService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateImageRequest request)
        {
            var result = await _createImageService.CreateAsync(request);
            return Ok(result);
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

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateImageRequest request)
        {
            var result = await _updateImageService.UpdateAsync(id, request);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _deleteImageService.DeleteAsync(id);

            if (result is null)
                return NotFound();

            return Ok(result);
        }
    }
}
