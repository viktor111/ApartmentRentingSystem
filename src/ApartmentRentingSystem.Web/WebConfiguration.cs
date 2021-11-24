namespace ApartmentRentingSystem.Web
{
    using Microsoft.Extensions.DependencyInjection;
    using FluentValidation.AspNetCore;
    using Application.Common;
    using Application.Contracts;
    using Services;
    
    public static class WebConfiguration
    {
        public static IServiceCollection AddWebComponents(this IServiceCollection services)
        {
            services
                .AddScoped<ICurrentUser, CurrentUser>()
                .AddControllers()
                .AddFluentValidation(validation => validation
                    .RegisterValidatorsFromAssemblyContaining<Result>())
                .AddNewtonsoftJson();

            return services;
        }
    }
}