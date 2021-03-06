

namespace ApartmentRentingSystem.Infrastructure.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;
    using Domain.Models.ApartmentAds;
    using Domain.Models.Landlords;
    using Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    internal class ApartmentRentalDbContext : IdentityDbContext<User>
    {
        public ApartmentRentalDbContext(DbContextOptions<ApartmentRentalDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApartmentAd> ApartmentAds { get; set; } = null!;

        public DbSet<Landlord> Landlords { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}