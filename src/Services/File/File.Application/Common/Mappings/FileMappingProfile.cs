using AutoMapper;
using File.Contracts.Files;
using File.Domain.Entities;

namespace File.Application.Common.Mappings
{
    public class FileMappingProfile : Profile
    {
        public FileMappingProfile()
        {
            CreateMap<FileRecord, UploadFileResponse>();
            CreateMap<FileRecord, GetFilesResponse>();
            CreateMap<FileRecord, GetFileByIdResponse>();
        }
    }
}
