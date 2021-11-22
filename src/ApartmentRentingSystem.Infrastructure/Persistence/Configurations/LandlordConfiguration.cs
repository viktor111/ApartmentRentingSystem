namespace ApartmentRentingSystem.Infrastructure.Persistence.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Domain.Models.Landlords;
    
    using static Domain.Models.ModelConstants.Common;
    using static Domain.Models.ModelConstants.PhoneNumber;
    

    internal class LandlordConfiguration : IEntityTypeConfiguration<Landlord>
    {
        public void Configure(EntityTypeBuilder<Landlord> builder)
        {
            builder
                .Property(l => l.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder.OwnsOne(l => l.PhoneNumber, p =>
            {
                p.WithOwner();

                p.Property(pn => pn.CountryCode)
                    .HasMaxLength(MaxCountryCodeLength)
                    .IsRequired();

                p.Property(pn => pn.Number)
                    .HasMaxLength(MaxPhoneNumberLength)
                    .IsRequired();
            });

            builder
                .HasMany(l => l.ApartmentAds)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("apartmentAds");
        }
    }
}