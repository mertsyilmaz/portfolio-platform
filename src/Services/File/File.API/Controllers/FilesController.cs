using File.Application.Files;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace File.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IUploadFileService _uploadFileService;
        private readonly IGetFilesService _getFilesService;
        private readonly IGetFileByIdService _getFileByIdService;
        private readonly IDeleteFileService _deleteFileService;

        public FilesController(
            IUploadFileService uploadFileService,
            IGetFilesService getFilesService,
            IGetFileByIdService getFileByIdService,
            IDeleteFileService deleteFileService)
        {
            _uploadFileService = uploadFileService;
            _getFilesService = getFilesService;
            _getFileByIdService = getFileByIdService;
            _deleteFileService = deleteFileService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file is null || file.Length == 0)
                return BadRequest("File is required.");

            var result = await _uploadFileService.UploadAsync(
                file.OpenReadStream(),
                file.FileName,
                file.ContentType,
                file.Length);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _getFilesService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _getFileByIdService.GetByIdAsync(id);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _deleteFileService.DeleteAsync(id);

            if (result is null)
                return NotFound();

            return Ok(result);
        }
    }
}
