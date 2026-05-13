using AutoMapper;
using File.Application.Abstractions.Persistence;
using File.Contracts.Files;

namespace File.Application.Files
{
    public class GetFilesService : IGetFilesService
    {
        private readonly IFileRepository _fileRepository;
        private readonly IMapper _mapper;

        public GetFilesService(IFileRepository fileRepository, IMapper mapper)
        {
            _fileRepository = fileRepository;
            _mapper = mapper;
        }

        public async Task<List<GetFilesResponse>> GetAllAsync()
        {
            var files = await _fileRepository.GetAllAsync();
            return _mapper.Map<List<GetFilesResponse>>(files);
        }
    }
}
