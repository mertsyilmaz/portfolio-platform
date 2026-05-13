using AutoMapper;
using Blog.Contracts.Tags;
using Blog.Domain.Entities;

namespace Blog.Application.Common.Mappings
{
    public class TagMappingProfile : Profile
    {
        public TagMappingProfile()
        {
            CreateMap<Tag, GetTagsResponse>();
            CreateMap<Tag, CreateTagResponse>();
            CreateMap<Tag, UpdateTagResponse>();

            CreateMap<CreateTagRequest, Tag>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));

            CreateMap<UpdateTagRequest, Tag>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Posts, opt => opt.Ignore());
        }
    }
}
