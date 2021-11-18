namespace ApartmentRentingSystem.Domain.Factories.ApartmentAds
{
    using System;
    using Exceptions;
    using Models.ApartmentAds;
    using FluentAssertions;
    using Xunit;

    public class ApartmentAdFactorySpecs
    {
        [Fact]
        public void BuildShouldThrowExceptionIfOptionsIsNotSet()
        {
            // Arrange
            var apartmentAdFactory = new ApartmentAdFactory();

            // Act
            Action act = () => apartmentAdFactory
                .WithRooms(new Rooms(1, 1, 1, 1))
                .Build();

            // Assert
            act.Should().Throw<InvalidApartmentAdException>();
        }
        
        [Fact]
        public void BuildShouldThrowExceptionIfRoomsIsNotSet()
        {
            // Arrange
            var apartmentAdFactory = new ApartmentAdFactory();

            // Act
            Action act = () => apartmentAdFactory
                .WithOptions(new Options(true,
                    true,
                    true, 
                    true, 
                    true,
                    true,
                    true,
                    true,
                    true,
                    true,
                    true,
                    true,
                    true,
                    true))
                .Build();

            // Assert
            act.Should().Throw<InvalidApartmentAdException>();
        }
        
        [Fact]
        public void BuildShouldCreateApartmentAdIfEveryPropertyIsSet()
        {
            // Arrange
            var apartmentAdFactory = new ApartmentAdFactory();

            // Act
            var apartmentAd = apartmentAdFactory
                .WithTitle("testop")
                .WithAddress("testuyiyu")
                .WithDescription("tesyuiyuit")
                .WithPrice(2m)
                .WithSquareMeters(23)
                .WithOptions(new Options(
                    true,
                    true,
                    true, 
                    true, 
                    true,
                    true,
                    true,
                    true,
                    true,
                    true,
                    true,
                    true,
                    true,
                    true
                    ))
                .WithRooms(new Rooms(
                    1,
                    1, 
                    1,
                    1
                    ))
                .Build();

            // Assert
            apartmentAd.Should().NotBeNull();
        }
    }
}