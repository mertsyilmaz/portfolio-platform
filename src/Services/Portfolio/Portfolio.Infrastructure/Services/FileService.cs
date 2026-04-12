using Portfolio.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

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

            throw new Exception("File service request failed.");
        }
    }
}
