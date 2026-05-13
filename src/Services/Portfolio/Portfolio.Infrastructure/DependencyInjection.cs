using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Application.Abstractions.Persistence;
using Portfolio.Application.Abstractions.Services;
using Portfolio.Infrastructure.Options;
using Portfolio.Infrastructure.Persistence;
using Portfolio.Infrastructure.Repositories;
using Portfolio.Infrastructure.Services;

namespace Portfolio.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PortfolioDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddHttpClient<IFileService, FileService>(client =>
            {
                client.BaseAddress = new Uri(configuration["Services:File:BaseUrl"]!);
            });

            services.AddOptions<FileServiceOptions>()
    .Bind(configuration.GetSection(FileServiceOptions.SectionName))
    .ValidateDataAnnotations()
    .ValidateOnStart();

            services.AddHttpClient<IFileService, FileService>(client =>
            {
                var fileServiceOptions = configuration
                    .GetSection(FileServiceOptions.SectionName)
                    .Get<FileServiceOptions>();

                if (fileServiceOptions is null || string.IsNullOrWhiteSpace(fileServiceOptions.BaseUrl))
                    throw new InvalidOperationException("File service BaseUrl configuration is missing.");

                client.BaseAddress = new Uri(fileServiceOptions.BaseUrl);
                client.Timeout = TimeSpan.FromSeconds(fileServiceOptions.TimeoutSeconds);

                client.DefaultRequestHeaders.Add("User-Agent", "PortfolioPlatform-PortfolioService");
            });

            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITechnologyRepository, TechnologyRepository>();
            services.AddScoped<IArchitectureRepository, ArchitectureRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();

            return services;
        }
    }
}
