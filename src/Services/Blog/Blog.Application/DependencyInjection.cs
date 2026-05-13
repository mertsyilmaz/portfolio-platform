using AutoMapper;
using Blog.Application.Abstractions.Rules;
using Blog.Application.Categories;
using Blog.Application.Comments;
using Blog.Application.Common.Mappings;
using Blog.Application.Common.Rules;
using Blog.Application.Common.Validators.Posts;
using Blog.Application.Images;
using Blog.Application.Posts;
using Blog.Application.Tags;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;

namespace Blog.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IMapper>(_ =>
    new MapperConfiguration(
        cfg => cfg.AddMaps(typeof(CategoryMappingProfile).Assembly),
        NullLoggerFactory.Instance
    ).CreateMapper());

            services.AddValidatorsFromAssemblyContaining<CreatePostRequestValidator>();

            services.AddScoped<IBlogReferenceValidationService, BlogReferenceValidationService>();

            services.AddScoped<ICreatePostService, CreatePostService>();
            services.AddScoped<IGetPostsService, GetPostsService>();
            services.AddScoped<IGetPostByIdService, GetPostByIdService>();
            services.AddScoped<IUpdatePostService, UpdatePostService>();
            services.AddScoped<IDeletePostService, DeletePostService>();

            services.AddScoped<ICreateCategoryService, CreateCategoryService>();
            services.AddScoped<IGetCategoriesService, GetCategoriesService>();
            services.AddScoped<IGetCategoryByIdService, GetCategoryByIdService>();
            services.AddScoped<IUpdateCategoryService, UpdateCategoryService>();
            services.AddScoped<IDeleteCategoryService, DeleteCategoryService>();

            services.AddScoped<ICreateTagService, CreateTagService>();
            services.AddScoped<IGetTagsService, GetTagsService>();
            services.AddScoped<IGetTagByIdService, GetTagByIdService>();
            services.AddScoped<IUpdateTagService, UpdateTagService>();
            services.AddScoped<IDeleteTagService, DeleteTagService>();

            services.AddScoped<ICreateCommentService, CreateCommentService>();
            services.AddScoped<IGetCommentsService, GetCommentsService>();
            services.AddScoped<IGetCommentByIdService, GetCommentByIdService>();
            services.AddScoped<IGetCommentsByPostIdService, GetCommentsByPostIdService>();
            services.AddScoped<IUpdateCommentService, UpdateCommentService>();
            services.AddScoped<IDeleteCommentService, DeleteCommentService>();

            services.AddScoped<ICreateImageService, CreateImageService>();
            services.AddScoped<IGetImagesService, GetImagesService>();
            services.AddScoped<IGetImageByIdService, GetImageByIdService>();
            services.AddScoped<IGetImagesByPostIdService, GetImagesByPostIdService>();
            services.AddScoped<IUpdateImageService, UpdateImageService>();
            services.AddScoped<IDeleteImageService, DeleteImageService>();

            return services;
        }
    }
}
