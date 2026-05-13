using FluentValidationException = FluentValidation.ValidationException;
using Identity.Application.Abstractions.Security;
using Identity.Application.Common.Exceptions;
using Identity.Infrastructure.Persistence;
using Identity.Infrastructure.Seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandling(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(exceptionApp =>
            {
                exceptionApp.Run(async context =>
                {
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = exceptionFeature?.Error;

                    var problemDetails = new ProblemDetails();

                    switch (exception)
                    {
                        case UnauthorizedException:
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            problemDetails.Status = StatusCodes.Status401Unauthorized;
                            problemDetails.Title = "Unauthorized";
                            problemDetails.Detail = exception.Message;
                            break;

                        case FluentValidationException fluentValidationException:
                            context.Response.StatusCode = StatusCodes.Status400BadRequest;
                            problemDetails.Status = StatusCodes.Status400BadRequest;
                            problemDetails.Title = "Validation error";
                            problemDetails.Detail = "One or more validation errors occurred.";
                            problemDetails.Extensions["errors"] = fluentValidationException.Errors
                                .GroupBy(x => x.PropertyName)
                                .ToDictionary(
                                    g => g.Key,
                                    g => g.Select(x => x.ErrorMessage).ToArray()
                                );
                            break;

                        case ValidationException:
                            context.Response.StatusCode = StatusCodes.Status400BadRequest;
                            problemDetails.Status = StatusCodes.Status400BadRequest;
                            problemDetails.Title = "Validation error";
                            problemDetails.Detail = exception.Message;
                            break;

                        case NotFoundException:
                            context.Response.StatusCode = StatusCodes.Status404NotFound;
                            problemDetails.Status = StatusCodes.Status404NotFound;
                            problemDetails.Title = "Resource not found";
                            problemDetails.Detail = exception.Message;
                            break;

                        case BusinessRuleException:
                            context.Response.StatusCode = StatusCodes.Status409Conflict;
                            problemDetails.Status = StatusCodes.Status409Conflict;
                            problemDetails.Title = "Business rule violation";
                            problemDetails.Detail = exception.Message;
                            break;

                        default:
                            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                            problemDetails.Status = StatusCodes.Status500InternalServerError;
                            problemDetails.Title = "Server error";
                            problemDetails.Detail = "An unexpected error occurred.";
                            break;
                    }

                    await context.Response.WriteAsJsonAsync(problemDetails);
                });
            });

            return app;
        }

        public static async Task SeedIdentityDataAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<IdentityDbContext>();
            var passwordService = scope.ServiceProvider.GetRequiredService<IPasswordService>();

            await IdentityDataSeeder.SeedAsync(context, passwordService);
        }
    }
}
