using File.API.Models;
using File.Application.Files;
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
        public async Task<IActionResult> Upload([FromForm] UploadFileFormRequest request)
        {
            await using var fileStream = request.File.OpenReadStream();

            var result = await _uploadFileService.UploadAsync(
                fileStream,
                request.File.FileName,
                request.File.ContentType,
                request.File.Length,
                request.FolderName);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
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
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _deleteFileService.DeleteAsync(id);
            return NoContent();
        }
    }
}
