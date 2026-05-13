using AutoMapper;
using File.Application.Common.Mappings;
using File.Application.Files;
using Microsoft.Extensions.DependencyInjection;

namespace File.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IMapper>(_ =>
                new MapperConfiguration(
    cfg => cfg.AddMaps(typeof(FileMappingProfile).Assembly),
    Microsoft.Extensions.Logging.Abstractions.NullLoggerFactory.Instance
).CreateMapper());

            services.AddScoped<IUploadFileService, UploadFileService>();
            services.AddScoped<IGetFilesService, GetFilesService>();
            services.AddScoped<IGetFileByIdService, GetFileByIdService>();
            services.AddScoped<IDeleteFileService, DeleteFileService>();

            return services;
        }
    }
}
