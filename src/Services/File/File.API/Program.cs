using File.Application.Abstractions.Persistence;
using File.Application.Abstractions.Storage;
using File.Application.Files;
using File.Infrastructure.Persistence;
using File.Infrastructure.Repositories;
using File.Infrastructure.Storage;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FileDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IFileRepository, FileRepository>();
builder.Services.AddScoped<IFileStorageService, DiskFileStorageService>();
builder.Services.AddScoped<IUploadFileService, UploadFileService>();
builder.Services.AddScoped<IGetFilesService, GetFilesService>();
builder.Services.AddScoped<IGetFileByIdService, GetFileByIdService>();
builder.Services.AddScoped<IDeleteFileService, DeleteFileService>();

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
