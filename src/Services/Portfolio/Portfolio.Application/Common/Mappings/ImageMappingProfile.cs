using AutoMapper;
using Portfolio.Contracts.Images;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Common.Mappings
{
    public class ImageMappingProfile : Profile
    {
        public ImageMappingProfile()
        {
            CreateMap<Image, GetImagesResponse>();
            CreateMap<Image, GetImageByIdResponse>();
            CreateMap<Image, CreateImageResponse>();
            CreateMap<Image, UpdateImageResponse>();

            CreateMap<CreateImageRequest, Image>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.Project, opt => opt.Ignore());

            CreateMap<UpdateImageRequest, Image>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Project, opt => opt.Ignore());
        }
    }
}
