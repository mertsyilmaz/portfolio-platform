using AutoMapper;
using Blog.Contracts.Categories;
using Blog.Contracts.Comments;
using Blog.Contracts.Images;
using Blog.Contracts.Tags;
using Blog.Domain.Entities;
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

            CreateMap<Tag, GetTagsResponse>();
            CreateMap<Tag, CreateTagResponse>();
            CreateMap<Tag, UpdateTagResponse>();

            CreateMap<Comment, GetCommentsResponse>();
            CreateMap<Comment, CreateCommentResponse>();
            CreateMap<Comment, UpdateCommentResponse>();

            CreateMap<DomainImageUsageType, ContractImageUsageType>()
                .ConvertUsing(src => (ContractImageUsageType)src);

            CreateMap<Image, GetImagesResponse>();
            CreateMap<Image, CreateImageResponse>();
            CreateMap<Image, UpdateImageResponse>();
        }
    }
}
