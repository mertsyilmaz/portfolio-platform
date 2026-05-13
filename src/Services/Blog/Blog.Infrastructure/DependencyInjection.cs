using Blog.Application.Abstractions.Persistence;
using Blog.Application.Abstractions.Services;
using Blog.Infrastructure.Options;
using Blog.Infrastructure.Persistence;
using Blog.Infrastructure.Repositories;
using Blog.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<BlogDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

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

                client.DefaultRequestHeaders.Add("User-Agent", "PortfolioPlatform-BlogService");
            });

            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();

            return services;
        }
    }
}