using CV.Application.Abstractions.Persistence;
using CV.Application.Abstractions.Services;
using CV.Infrastructure.Persistence;
using CV.Infrastructure.Repositories;
using CV.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CV.Infrastructure.Options;

namespace CV.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CvDbContext>(options =>
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

                client.DefaultRequestHeaders.Add("User-Agent", "PortfolioPlatform-CVService");
            });

            services.AddScoped<IExperienceRepository, ExperienceRepository>();
            services.AddScoped<IEducationRepository, EducationRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IPersonalInfoRepository, PersonalInfoRepository>();
            services.AddScoped<ISocialLinkRepository, SocialLinkRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<ICertificateRepository, CertificateRepository>();
            services.AddScoped<IHobbyRepository, HobbyRepository>();

            return services;
        }
    }
}
