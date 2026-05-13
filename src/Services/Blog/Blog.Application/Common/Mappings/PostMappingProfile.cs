using AutoMapper;
using Blog.Contracts.Posts;
using Blog.Domain.Entities;

namespace Blog.Application.Common.Mappings
{
    public class PostMappingProfile : Profile
    {
        public PostMappingProfile()
        {
            CreateMap<Post, CreatePostResponse>();
            CreateMap<Post, UpdatePostResponse>();
            CreateMap<Post, GetPostsResponse>();
            CreateMap<Post, GetPostByIdResponse>();

            CreateMap<CreatePostRequest, Post>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.PublishedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Categories, opt => opt.Ignore())
                .ForMember(dest => dest.Tags, opt => opt.Ignore())
                .ForMember(dest => dest.Comments, opt => opt.Ignore())
                .ForMember(dest => dest.Images, opt => opt.Ignore());

            CreateMap<UpdatePostRequest, Post>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.AuthorId, opt => opt.Ignore())
                    .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                    .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                    .ForMember(dest => dest.PublishedAt, opt => opt.Ignore())
                    .ForMember(dest => dest.Categories, opt => opt.Ignore())
                    .ForMember(dest => dest.Tags, opt => opt.Ignore())
                    .ForMember(dest => dest.Comments, opt => opt.Ignore())
                    .ForMember(dest => dest.Images, opt => opt.Ignore());
        }
    }
}
