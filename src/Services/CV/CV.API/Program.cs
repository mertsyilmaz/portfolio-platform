using CV.Application.Abstractions.Persistence;
using CV.Application.Certificates;
using CV.Application.Educations;
using CV.Application.Experiences;
using CV.Application.Hobbies;
using CV.Application.Languages;
using CV.Application.PersonalInfos;
using CV.Application.Skills;
using CV.Application.SocialLinks;
using CV.Infrastructure.Persistence;
using CV.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using CV.Application.Abstractions.Services;
using CV.Infrastructure.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CvDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpClient<IFileService, FileService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["Services:File:BaseUrl"]!);
});

builder.Services.AddScoped<IExperienceRepository, ExperienceRepository>();
builder.Services.AddScoped<ICreateExperienceService,CreateExperienceService>();
builder.Services.AddScoped<IGetExperienceService, GetExperienceService>();
builder.Services.AddScoped<IGetExperienceByIdService, GetExperienceByIdService>();
builder.Services.AddScoped<IUpdateExperienceService, UpdateExperienceService>();
builder.Services.AddScoped<IDeleteExperienceService, DeleteExperienceService>();

builder.Services.AddScoped<IEducationRepository, EducationRepository>();
builder.Services.AddScoped<ICreateEducationService, CreateEducationService>();
builder.Services.AddScoped<IGetEducationsService, GetEducationsService>();
builder.Services.AddScoped<IGetEducationByIdService, GetEducationByIdService>();
builder.Services.AddScoped<IUpdateEducationService, UpdateEducationService>();
builder.Services.AddScoped<IDeleteEducationService, DeleteEducationService>();

builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<ICreateSkillService, CreateSkillService>();
builder.Services.AddScoped<IGetSkillsService, GetSkillsService>();
builder.Services.AddScoped<IGetSkillByIdService, GetSkillByIdService>();
builder.Services.AddScoped<IUpdateSkillService, UpdateSkillService>();
builder.Services.AddScoped<IDeleteSkillService, DeleteSkillService>();

builder.Services.AddScoped<IPersonalInfoRepository, PersonalInfoRepository>();
builder.Services.AddScoped<ICreatePersonalInfoService, CreatePersonalInfoService>();
builder.Services.AddScoped<IGetPersonalInfosService, GetPersonalInfoService>();
builder.Services.AddScoped<IUpdatePersonalInfoService, UpdatePersonalInfoService>();
builder.Services.AddScoped<IDeletePersonalInfoService, DeletePersonalInfoService>();

builder.Services.AddScoped<ISocialLinkRepository, SocialLinkRepository>();
builder.Services.AddScoped<ICreateSocialLinkService, CreateSocialLinkService>();
builder.Services.AddScoped<IGetSocialLinksService, GetSocialLinksService>();
builder.Services.AddScoped<IGetSocialLinkByIdService, GetSocialLinkByIdService>();
builder.Services.AddScoped<IUpdateSocialLinkService, UpdateSocialLinkService>();
builder.Services.AddScoped<IDeleteSocialLinkService, DeleteSocialLinkService>();

builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
builder.Services.AddScoped<ICreateLanguageService, CreateLanguageService>();
builder.Services.AddScoped<IGetLanguagesService, GetLanguagesService>();
builder.Services.AddScoped<IGetLanguageByIdService, GetLanguageByIdService>();
builder.Services.AddScoped<IUpdateLanguageService, UpdateLanguageService>();
builder.Services.AddScoped<IDeleteLanguageService, DeleteLanguageService>();

builder.Services.AddScoped<ICertificateRepository, CertificateRepository>();
builder.Services.AddScoped<ICreateCertificateService, CreateCertificateService>();
builder.Services.AddScoped<IGetCertificatesService, GetCertificatesService>();
builder.Services.AddScoped<IGetCertificateByIdService, GetCertificateByIdService>();
builder.Services.AddScoped<IUpdateCertificateService, UpdateCertificateService>();
builder.Services.AddScoped<IDeleteCertificateService, DeleteCertificateService>();

builder.Services.AddScoped<IHobbyRepository, HobbyRepository>();
builder.Services.AddScoped<ICreateHobbyService, CreateHobbyService>();
builder.Services.AddScoped<IGetHobbiesService, GetHobbiesService>();
builder.Services.AddScoped<IGetHobbyByIdService, GetHobbyByIdService>();
builder.Services.AddScoped<IUpdateHobbyService, UpdateHobbyService>();
builder.Services.AddScoped<IDeleteHobbyService, DeleteHobbyService>();

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
