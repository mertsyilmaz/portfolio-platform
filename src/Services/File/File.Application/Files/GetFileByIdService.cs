using AutoMapper;
using File.Application.Abstractions.Persistence;
using File.Application.Common.Exceptions;
using File.Contracts.Files;

namespace File.Application.Files
{
    public class GetFileByIdService : IGetFileByIdService
    {
        private readonly IFileRepository _fileRepository;
        private readonly IMapper _mapper;

        public GetFileByIdService(IFileRepository fileRepository, IMapper mapper)
        {
            _fileRepository = fileRepository;
            _mapper = mapper;
        }

        public async Task<GetFileByIdResponse> GetByIdAsync(Guid id)
        {
            var file = await _fileRepository.GetByIdAsync(id);
            Guard.AgainstNotFound(file, ErrorMessages.FileNotFound);

            return _mapper.Map<GetFileByIdResponse>(file);
        }
    }
}
