using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Application.Architectures;
using Portfolio.Application.Categories;
using Portfolio.Application.Images;
using Portfolio.Application.Projects;
using Portfolio.Application.Technologies;
using Portfolio.Infrastructure.Persistence;
using Portfolio.Infrastructure.Repositories;
using Portfolio.Application.Abstractions.Services;
using Portfolio.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PortfolioDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpClient<IFileService, FileService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["Services:File:BaseUrl"]!);
});

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<ICreateProjectService, CreateProjectService>();
builder.Services.AddScoped<IGetProjectsService, GetProjectsService>();
builder.Services.AddScoped<IGetProjectByIdService, GetProjectByIdService>();
builder.Services.AddScoped<IUpdateProjectService, UpdateProjectService>();
builder.Services.AddScoped<IDeleteProjectService, DeleteProjectService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICreateCategoryService, CreateCategoryService>();
builder.Services.AddScoped<IGetCategoriesService, GetCategoriesService>();
builder.Services.AddScoped<IGetCategoryByIdService, GetCategoryByIdService>();
builder.Services.AddScoped<IUpdateCategoryService, UpdateCategoryService>();
builder.Services.AddScoped<IDeleteCategoryService, DeleteCategoryService>();

builder.Services.AddScoped<ITechnologyRepository, TechnologyRepository>();
builder.Services.AddScoped<ICreateTechnologyService, CreateTechnologyService>();
builder.Services.AddScoped<IGetTechnologiesService, GetTechnologiesService>();
builder.Services.AddScoped<IGetTechnologyByIdService, GetTechnologyByIdService>();
builder.Services.AddScoped<IUpdateTechnologyService, UpdateTechnologyService>();
builder.Services.AddScoped<IDeleteTechnologyService, DeleteTechnologyService>();

builder.Services.AddScoped<IArchitectureRepository, ArchitectureRepository>();
builder.Services.AddScoped<ICreateArchitectureService, CreateArchitectureService>();
builder.Services.AddScoped<IGetArchitecturesService, GetArchitecturesService>();
builder.Services.AddScoped<IGetArchitectureByIdService, GetArchitectureByIdService>();
builder.Services.AddScoped<IUpdateArchitectureService, UpdateArchitectureService>();
builder.Services.AddScoped<IDeleteArchitectureService, DeleteArchitectureService>();

builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<ICreateImageService, CreateImageService>();
builder.Services.AddScoped<IGetImagesService, GetImagesService>();
builder.Services.AddScoped<IGetImageByIdService, GetImageByIdService>();
builder.Services.AddScoped<IUpdateImageService, UpdateImageService>();
builder.Services.AddScoped<IDeleteImageService, DeleteImageService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
