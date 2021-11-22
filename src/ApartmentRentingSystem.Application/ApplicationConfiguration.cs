
using System.Reflection;
using MediatR;

namespace ApartmentRentingSystem.Application
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .Configure<ApplicationSettings>(
                    configuration.GetSection(nameof(ApplicationSettings)), 
                    options => options.BindNonPublicProperties = true)
                .AddMediatR(Assembly.GetExecutingAssembly());
    }
}