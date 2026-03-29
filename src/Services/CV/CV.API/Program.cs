using CV.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using CV.Application.Abstractions.Persistence;
using CV.Application.Experiences;
using CV.Infrastructure.Repositories;


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
