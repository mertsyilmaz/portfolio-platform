using Blog.Application.Abstractions.Persistence;
using Blog.Application.Abstractions.Services;
using Blog.Application.Categories;
using Blog.Application.Comments;
using Blog.Application.Common.Mappings;
using Blog.Application.Images;
using Blog.Application.Posts;
using Blog.Application.Tags;
using Blog.Infrastructure.Persistence;
using Blog.Infrastructure.Repositories;
using Blog.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Blog.Application.Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Blog.Application.Common.Validators.Posts;
using FluentValidation;
using FluentValidationException = FluentValidation.ValidationException;
using AppValidationException = Blog.Application.Common.Exceptions.ValidationException;
using FluentValidation.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProblemDetails();



builder.Services.AddValidatorsFromAssemblyContaining<CreatePostRequestValidator>();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddAutoMapper(typeof(BlogMappingProfile));

builder.Services.AddDbContext<BlogDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpClient<IFileService, FileService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["Services:File:BaseUrl"]!);
});

builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ICreatePostService, CreatePostService>();
builder.Services.AddScoped<IGetPostsService, GetPostsService>();
builder.Services.AddScoped<IGetPostByIdService, GetPostByIdService>();
builder.Services.AddScoped<IUpdatePostService, UpdatePostService>();
builder.Services.AddScoped<IDeletePostService, DeletePostService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICreateCategoryService, CreateCategoryService>();
builder.Services.AddScoped<IGetCategoriesService, GetCategoriesService>();
builder.Services.AddScoped<IGetCategoryByIdService, GetCategoryByIdService>();
builder.Services.AddScoped<IUpdateCategoryService, UpdateCategoryService>();
builder.Services.AddScoped<IDeleteCategoryService, DeleteCategoryService>();

builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<ICreateTagService, CreateTagService>();
builder.Services.AddScoped<IGetTagsService, GetTagsService>();
builder.Services.AddScoped<IGetTagByIdService, GetTagByIdService>();
builder.Services.AddScoped<IUpdateTagService, UpdateTagService>();
builder.Services.AddScoped<IDeleteTagService, DeleteTagService>();

builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICreateCommentService, CreateCommentService>();
builder.Services.AddScoped<IGetCommentsService, GetCommentsService>();
builder.Services.AddScoped<IGetCommentByIdService, GetCommentByIdService>();
builder.Services.AddScoped<IGetCommentsByPostIdService, GetCommentsByPostIdService>();
builder.Services.AddScoped<IUpdateCommentService, UpdateCommentService>();
builder.Services.AddScoped<IDeleteCommentService, DeleteCommentService>();

builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<ICreateImageService, CreateImageService>();
builder.Services.AddScoped<IGetImagesService, GetImagesService>();
builder.Services.AddScoped<IGetImageByIdService, GetImageByIdService>();
builder.Services.AddScoped<IGetImagesByPostIdService, GetImagesByPostIdService>();
builder.Services.AddScoped<IUpdateImageService, UpdateImageService>();
builder.Services.AddScoped<IDeleteImageService, DeleteImageService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(exceptionApp =>
{
    exceptionApp.Run(async context =>
    {
        var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
        var exception = exceptionFeature?.Error;

        var problemDetails = new ProblemDetails();

        switch (exception)
        {
            case NotFoundException:
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                problemDetails.Status = StatusCodes.Status404NotFound;
                problemDetails.Title = "Resource not found";
                problemDetails.Detail = exception.Message;
                break;

            case FluentValidationException fluentValidationException:
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                problemDetails.Status = StatusCodes.Status400BadRequest;
                problemDetails.Title = "Validation error";
                problemDetails.Detail = "One or more validation errors occurred.";
                problemDetails.Extensions["errors"] = fluentValidationException.Errors
                    .GroupBy(x => x.PropertyName)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(x => x.ErrorMessage).ToArray()
                    );
                break;

            case AppValidationException:
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                problemDetails.Status = StatusCodes.Status400BadRequest;
                problemDetails.Title = "Validation error";
                problemDetails.Detail = exception.Message;
                break;

            case BusinessRuleException:
                context.Response.StatusCode = StatusCodes.Status409Conflict;
                problemDetails.Status = StatusCodes.Status409Conflict;
                problemDetails.Title = "Business rule violation";
                problemDetails.Detail = exception.Message;
                break;

            default:
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                problemDetails.Status = StatusCodes.Status500InternalServerError;
                problemDetails.Title = "Server error";
                problemDetails.Detail = "An unexpected error occurred.";
                break;
        }



        await context.Response.WriteAsJsonAsync(problemDetails);
    });
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
