namespace ApartmentRentingSystem.Infrastructure.Persistence.Configurations
{
    using Domain.Models.ApartmentAds;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    
    using static Domain.Models.ModelConstants.ApartmentAds;
    using static Domain.Models.ModelConstants.Address;
    using static Domain.Models.ModelConstants.Rooms;

    internal class ApartmentAdConfiguration : IEntityTypeConfiguration<ApartmentAd>
    {
        public void Configure(EntityTypeBuilder<ApartmentAd> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(MaxTitleLength);

            builder
                .OwnsOne(a => a.Address, ad =>
                {
                    ad.WithOwner();

                    ad.Property(a => a.Country);

                    ad.Property(a => a.City);

                    ad.Property(a => a.Street);
                });

            builder
                .Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(MaxDescriptionLength);
            
            builder
                .Property(a => a.Price)
                .IsRequired()
                .HasColumnType("decimal(18,4)"); ;

            builder
                .Property(a => a.SquareMeters)
                .IsRequired();

            builder.OwnsOne(a => a.Options, o =>
            {
                o.WithOwner();
                
                o
                    .Property(op => op.HasFurniture)
                    .IsRequired();

                o
                    .Property(op => op.HasParking)
                    .IsRequired();
                
                o
                    .Property(op => op.HasGarden)
                    .IsRequired();
                
                o
                    .Property(op => op.HasLift)
                    .IsRequired();
                
                o
                    .Property(op => op.HasAirConditioner)
                    .IsRequired();
                
                o
                    .Property(op => op.HasTv)
                    .IsRequired();
                
                o
                    .Property(op => op.HasInternet)
                    .IsRequired();
                
                o
                    .Property(op => op.HasPhone)
                    .IsRequired();
                
                o
                    .Property(op => op.HasWashingMachine)
                    .IsRequired();
                
                o
                    .Property(op => op.HasDishwasher)
                    .IsRequired();
                
                o
                    .Property(op => op.HasRefrigerator)
                    .IsRequired();
                
                o
                    .Property(op => op.HasMicrowave)
                    .IsRequired();
                
                o
                    .Property(op => op.HasOven)
                    .IsRequired();
                
                o
                    .Property(op => op.HasCoffeeMachine)
                    .IsRequired();
                
            });

            builder.OwnsOne(a => a.Rooms, r =>
            {
                r.WithOwner();
                
                r
                    .Property(a => a.NumberOfRooms)
                    .HasMaxLength(MaxNumberOfRooms)
                    .IsRequired();

                r
                    .Property(a => a.NumberOfBathrooms)
                    .HasMaxLength(MaxNumberOfBathrooms)
                    .IsRequired();

                r
                    .Property(a => a.NumberOfBedrooms)
                    .HasMaxLength(MaxNumberOfBedrooms)
                    .IsRequired();

                r
                    .Property(a => a.NumberOfBalconies)
                    .HasMaxLength(MaxNumberOfBalconies)
                    .IsRequired();
            });
            
            builder
                .Property(a => a.IsAvailable)
                .IsRequired();
            
        }
    }
}