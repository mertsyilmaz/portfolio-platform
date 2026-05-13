using FluentValidation;
using Identity.Application.Auth;
using Identity.Application.Common.Validators.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
