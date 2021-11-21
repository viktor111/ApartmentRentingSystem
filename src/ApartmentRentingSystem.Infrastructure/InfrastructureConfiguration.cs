namespace ApartmentRentingSystem.Infrastructure
{
    using Application.Contracts;
    using Persistence;
    using Persistence.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            return services
                .AddDbContext<ApartmentRentalDbContext>(options => options
                    .UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(ApartmentRentalDbContext).Assembly.FullName)))
                .AddTransient(typeof(IRepository<>), typeof(DataRepository<>));
        }
    }
}