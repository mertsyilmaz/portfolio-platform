using AutoMapper;
using Blog.Contracts.Images;
using Blog.Domain.Entities;
using ContractImageUsageType = Blog.Contracts.Enums.ImageUsageType;
using DomainImageUsageType = Blog.Domain.Enums.ImageUsageType;

namespace Blog.Application.Common.Mappings
{
    public class ImageMappingProfile : Profile
    {
        public ImageMappingProfile()
        {
            CreateMap<Image, GetImagesResponse>();
            CreateMap<Image, CreateImageResponse>();
            CreateMap<Image, UpdateImageResponse>();

            CreateMap<CreateImageRequest, Image>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.UsageType, opt => opt.MapFrom(src => (DomainImageUsageType)src.UsageType))
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Post, opt => opt.Ignore());

            CreateMap<UpdateImageRequest, Image>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.PostId, opt => opt.Ignore())
                    .ForMember(dest => dest.UsageType, opt => opt.MapFrom(src => (DomainImageUsageType)src.UsageType))
                    .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                    .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                    .ForMember(dest => dest.Post, opt => opt.Ignore());

            CreateMap<DomainImageUsageType, ContractImageUsageType>()
                    .ConvertUsing(src => (ContractImageUsageType)src);
        }
    }
}
