using ApartmentRentingSystem.Domain.Models.Landlords;

namespace ApartmentRentingSystem.Domain.Factories.Landlords
{
    using System;
    using Exceptions;
    using FluentAssertions;
    using Xunit;
    
    public class LandlordFactorySpecs
    {
        [Fact]
        public void BuildShouldThrowExceptionIfPhoneNumberIsNotSet()
        {
            // Arrange
            var landlordFactory = new LandlordFactory();

            // Act
            Action action = () => landlordFactory.Build();

            // Assert
            action.Should().Throw<InvalidLandlordException>();
        }

        [Fact]
        public void BuildShouldCreateLandlordIfEveryPropertyIsSet()
        {
            // Arrange
            var landlordFactory = new LandlordFactory();
            
            // Act
            var landlord = landlordFactory
                .WithName("Testname")
                .WithPhoneNumber(new PhoneNumber("+345", "9243573"));

            // Assert
            landlord.Should().NotBeNull();
        }
    }
}