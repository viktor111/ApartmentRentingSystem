namespace ApartmentRentingSystem.Infrastructure.Persistence.Configurations
{
    using Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasOne(u => u.Landlord)
                .WithOne()
                .HasForeignKey<User>("LandlordId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}