using CV.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using CV.Application.Abstractions.Persistence;
using CV.Application.Experiences;
using CV.Infrastructure.Repositories;
using CV.Application.Educations;
using CV.Application.Skills;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CvDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

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
