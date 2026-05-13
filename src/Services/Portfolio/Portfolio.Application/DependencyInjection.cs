using Microsoft.Extensions.DependencyInjection;
using Portfolio.Application.Abstractions.Rules;
using Portfolio.Application.Architectures;
using Portfolio.Application.Categories;
using Portfolio.Application.Common.Mappings;
using Portfolio.Application.Common.Rules;
using Portfolio.Application.Images;
using Portfolio.Application.Projects;
using Portfolio.Application.Technologies;

namespace Portfolio.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<AutoMapper.IMapper>(_ =>
                new AutoMapper.MapperConfiguration(
    cfg => cfg.AddMaps(typeof(CategoryMappingProfile).Assembly),
    Microsoft.Extensions.Logging.Abstractions.NullLoggerFactory.Instance
).CreateMapper());

            services.AddScoped<IPortfolioReferenceValidationService, PortfolioReferenceValidationService>();

            services.AddScoped<ICreateProjectService, CreateProjectService>();
            services.AddScoped<IGetProjectsService, GetProjectsService>();
            services.AddScoped<IGetProjectByIdService, GetProjectByIdService>();
            services.AddScoped<IUpdateProjectService, UpdateProjectService>();
            services.AddScoped<IDeleteProjectService, DeleteProjectService>();

            services.AddScoped<ICreateCategoryService, CreateCategoryService>();
            services.AddScoped<IGetCategoriesService, GetCategoriesService>();
            services.AddScoped<IGetCategoryByIdService, GetCategoryByIdService>();
            services.AddScoped<IUpdateCategoryService, UpdateCategoryService>();
            services.AddScoped<IDeleteCategoryService, DeleteCategoryService>();

            services.AddScoped<ICreateTechnologyService, CreateTechnologyService>();
            services.AddScoped<IGetTechnologiesService, GetTechnologiesService>();
            services.AddScoped<IGetTechnologyByIdService, GetTechnologyByIdService>();
            services.AddScoped<IUpdateTechnologyService, UpdateTechnologyService>();
            services.AddScoped<IDeleteTechnologyService, DeleteTechnologyService>();

            services.AddScoped<ICreateArchitectureService, CreateArchitectureService>();
            services.AddScoped<IGetArchitecturesService, GetArchitecturesService>();
            services.AddScoped<IGetArchitectureByIdService, GetArchitectureByIdService>();
            services.AddScoped<IUpdateArchitectureService, UpdateArchitectureService>();
            services.AddScoped<IDeleteArchitectureService, DeleteArchitectureService>();

            services.AddScoped<ICreateImageService, CreateImageService>();
            services.AddScoped<IGetImagesService, GetImagesService>();
            services.AddScoped<IGetImageByIdService, GetImageByIdService>();
            services.AddScoped<IUpdateImageService, UpdateImageService>();
            services.AddScoped<IDeleteImageService, DeleteImageService>();

            return services;
        }
    }
}
