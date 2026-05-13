using AutoMapper;
using CV.Application.Abstractions.Rules;
using CV.Application.Certificates;
using CV.Application.Common.Rules;
using CV.Application.Educations;
using CV.Application.Experiences;
using CV.Application.Hobbies;
using CV.Application.Languages;
using CV.Application.PersonalInfos;
using CV.Application.Skills;
using CV.Application.SocialLinks;
using Microsoft.Extensions.DependencyInjection;

namespace CV.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IMapper>(_ =>
                new MapperConfiguration(
    cfg => cfg.AddMaps(typeof(DependencyInjection).Assembly),
    Microsoft.Extensions.Logging.Abstractions.NullLoggerFactory.Instance
).CreateMapper());

            services.AddScoped<ICvReferenceValidationService, CvReferenceValidationService>();

            services.AddScoped<ICreateExperienceService, CreateExperienceService>();
            services.AddScoped<IGetExperienceService, GetExperienceService>();
            services.AddScoped<IGetExperienceByIdService, GetExperienceByIdService>();
            services.AddScoped<IUpdateExperienceService, UpdateExperienceService>();
            services.AddScoped<IDeleteExperienceService, DeleteExperienceService>();

            services.AddScoped<ICreateEducationService, CreateEducationService>();
            services.AddScoped<IGetEducationsService, GetEducationsService>();
            services.AddScoped<IGetEducationByIdService, GetEducationByIdService>();
            services.AddScoped<IUpdateEducationService, UpdateEducationService>();
            services.AddScoped<IDeleteEducationService, DeleteEducationService>();

            services.AddScoped<ICreateSkillService, CreateSkillService>();
            services.AddScoped<IGetSkillsService, GetSkillsService>();
            services.AddScoped<IGetSkillByIdService, GetSkillByIdService>();
            services.AddScoped<IUpdateSkillService, UpdateSkillService>();
            services.AddScoped<IDeleteSkillService, DeleteSkillService>();

            services.AddScoped<ICreatePersonalInfoService, CreatePersonalInfoService>();
            services.AddScoped<IGetPersonalInfosService, GetPersonalInfoService>();
            services.AddScoped<IUpdatePersonalInfoService, UpdatePersonalInfoService>();
            services.AddScoped<IDeletePersonalInfoService, DeletePersonalInfoService>();

            services.AddScoped<ICreateSocialLinkService, CreateSocialLinkService>();
            services.AddScoped<IGetSocialLinksService, GetSocialLinksService>();
            services.AddScoped<IGetSocialLinkByIdService, GetSocialLinkByIdService>();
            services.AddScoped<IUpdateSocialLinkService, UpdateSocialLinkService>();
            services.AddScoped<IDeleteSocialLinkService, DeleteSocialLinkService>();

            services.AddScoped<ICreateLanguageService, CreateLanguageService>();
            services.AddScoped<IGetLanguagesService, GetLanguagesService>();
            services.AddScoped<IGetLanguageByIdService, GetLanguageByIdService>();
            services.AddScoped<IUpdateLanguageService, UpdateLanguageService>();
            services.AddScoped<IDeleteLanguageService, DeleteLanguageService>();

            services.AddScoped<ICreateCertificateService, CreateCertificateService>();
            services.AddScoped<IGetCertificatesService, GetCertificatesService>();
            services.AddScoped<IGetCertificateByIdService, GetCertificateByIdService>();
            services.AddScoped<IUpdateCertificateService, UpdateCertificateService>();
            services.AddScoped<IDeleteCertificateService, DeleteCertificateService>();

            services.AddScoped<ICreateHobbyService, CreateHobbyService>();
            services.AddScoped<IGetHobbiesService, GetHobbiesService>();
            services.AddScoped<IGetHobbyByIdService, GetHobbyByIdService>();
            services.AddScoped<IUpdateHobbyService, UpdateHobbyService>();
            services.AddScoped<IDeleteHobbyService, DeleteHobbyService>();

            return services;
        }
    }
}
