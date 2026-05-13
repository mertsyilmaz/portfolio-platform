using File.Application.Abstractions.Persistence;
using File.Application.Abstractions.Storage;
using File.Infrastructure.Persistence;
using File.Infrastructure.Repositories;
using File.Infrastructure.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace File.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FileDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IFileRepository, FileRepository>();
            services.AddScoped<IFileStorageService, DiskFileStorageService>();

            return services;
        }
    }
}
