using Microsoft.AspNetCore.Http;

namespace File.API.Models
{
    public class UploadFileFormRequest
    {
        public IFormFile File { get; set; } = null!;

        public string FolderName { get; set; } = null!;
    }
}
