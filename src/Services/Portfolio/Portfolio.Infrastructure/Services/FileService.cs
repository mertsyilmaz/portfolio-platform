using Portfolio.Application.Abstractions.Services;
using Portfolio.Application.Common.Exceptions;
using System.Net;

namespace Portfolio.Infrastructure.Services
{
    public class FileService : IFileService
    {
        private readonly HttpClient _httpClient;

        public FileService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> ExistsAsync(Guid fileId)
        {
            var response = await _httpClient.GetAsync($"/api/files/{fileId}");

            if (response.IsSuccessStatusCode)
                return true;

            if (response.StatusCode == HttpStatusCode.NotFound)
                return false;

            throw new ExternalServiceException(ErrorMessages.FileServiceRequestFailed);
        }
    }
}
