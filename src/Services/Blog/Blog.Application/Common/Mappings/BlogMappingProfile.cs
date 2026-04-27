using AutoMapper;
using Blog.Contracts.Categories;
using Blog.Contracts.Comments;
using Blog.Contracts.Images;
using Blog.Contracts.Tags;
using Blog.Domain.Entities;
using Blog.Contracts.Posts;
using ContractImageUsageType = Blog.Contracts.Enums.ImageUsageType;
using DomainImageUsageType = Blog.Domain.Enums.ImageUsageType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Common.Mappings
{
    public class BlogMappingProfile : Profile
    {
        public BlogMappingProfile()
        {
            CreateMap<Category, GetCategoriesResponse>();
            CreateMap<Category, CreateCategoryResponse>();
            CreateMap<Category, UpdateCategoryResponse>();

            CreateMap<CreateCategoryRequest, Category>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));

            CreateMap<UpdateCategoryRequest, Category>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Posts, opt => opt.Ignore());

            CreateMap<Tag, GetTagsResponse>();
            CreateMap<Tag, CreateTagResponse>();
            CreateMap<Tag, UpdateTagResponse>();

            CreateMap<CreateTagRequest, Tag>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));

            CreateMap<UpdateTagRequest, Tag>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Posts, opt => opt.Ignore());

            CreateMap<Comment, GetCommentsResponse>();
            CreateMap<Comment, CreateCommentResponse>();
            CreateMap<Comment, UpdateCommentResponse>();

            CreateMap<CreateCommentRequest, Comment>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.IsApproved, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Post, opt => opt.Ignore());

            CreateMap<UpdateCommentRequest, Comment>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.PostId, opt => opt.Ignore())
                .ForMember(dest => dest.AuthorId, opt => opt.Ignore())
                .ForMember(dest => dest.IsApproved, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Post, opt => opt.Ignore());

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

            CreateMap<DomainImageUsageType, ContractImageUsageType>()
                .ConvertUsing(src => (ContractImageUsageType)src);
        }
    }
}
