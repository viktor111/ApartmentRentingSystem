namespace ApartmentRentingSystem.Web
{
    using Microsoft.Extensions.DependencyInjection;
    using FluentValidation.AspNetCore;
    using Application.Common;
    using Application.Contracts;
    using Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.OpenApi.Models;

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

            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Example API", Version = "v1"});

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Scheme = "bearer",
                    Description = "Please insert JWT token into field"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });

            return services;
        }
    }
}