namespace ApartmentRentingSystem.Domain.Models.ApartmentAds
{
    using FakeItEasy;
    using FluentAssertions;
    using Xunit;
    using System;
    using Exceptions;
    
    using static  ModelConstants.ApartmentAds;

    public class ApartmentAdSpecs
    {
        [Fact]
        public void ShouldUpdateTitle()
        {
            // Arrange
            var apartmentAd = A.Dummy<ApartmentAd>();
            var tittle = "Title";
            
            // Act
            apartmentAd.UpdateTitle(tittle);
            
            // Assert
            apartmentAd.Title.Should().Be(tittle);
        }
        
        [Fact]
        public void ShouldThrowExceptionWhenTitleIsNull()
        {
            // Arrange
            var apartmentAd = A.Dummy<ApartmentAd>();
            var tittle = string.Empty;
            
            // Act
            Action action = () => apartmentAd.UpdateTitle(tittle);
            
            // Assert
            action.Should().Throw<InvalidApartmentAdException>();
        }

        [Fact]
        public void ShouldThrowExceptionWhenUpdateTitleExceedsMaxLength()
        {
            // Arrange
            var apartmentAd = A.Dummy<ApartmentAd>();
            var random = new Bogus.Randomizer();
            
            // Act
            Action action = () => apartmentAd.UpdateTitle(random.String(MaxTitleLength + 1));
            
            // Assert
            action.Should().Throw<InvalidApartmentAdException>();
        }
        
        [Fact]
        public void ShouldThrowExceptionWhenUpdateTitleIsLessThanMinLength()
        {
            // Arrange
            var apartmentAd = A.Dummy<ApartmentAd>();
            var random = new Bogus.Randomizer();
            
            // Act
            Action action = () => apartmentAd.UpdateTitle(random.String(MinTitleLength - 1));
            
            // Assert
            action.Should().Throw<InvalidApartmentAdException>();
        }

        [Theory]
        [InlineData("testertestertester")]
        [InlineData("qqwfqqtqwqr")]
        public void ShouldUpdateDescription(string description)
        {
            // Arrange
            var apartmentAd = A.Dummy<ApartmentAd>();

            // Act
            apartmentAd.UpdateDescription(description);

            // Assert
            apartmentAd.Description.Should().Be(description);
        }

        [Theory]
        [InlineData(null)]
        public void ShouldThrowExceptionWhenUpdateDescriptionIsNull(string description)
        {
            // Arrange
            var apartmentAd = A.Dummy<ApartmentAd>();

            // Act
            Action act = () => apartmentAd.UpdateDescription(description);

            // Assert
            act.Should().Throw<InvalidApartmentAdException>();
        }

        [Fact]
        public void ShouldThrowExceptionWhenUpdateDescriptionExceedsMaxLength()
        {
            // Arrange
            var apartmentAd = A.Dummy<ApartmentAd>();
            var random = new Bogus.Randomizer();

            // Act
            Action act = () => apartmentAd.UpdateDescription(random.String(1001));

            // Assert
            act.Should().Throw<InvalidApartmentAdException>();
        }

        [Fact]
        public void ShouldThrowExceptionWhenUpdateDescriptionMinLengthIsNotMet()
        {
            // Arrange
            var apartmentAd = A.Dummy<ApartmentAd>();

            // Act
            Action act = () => apartmentAd.UpdateDescription("awwe");

            // Assert
            act.Should().Throw<InvalidApartmentAdException>();
        }
        
        // Test price
        [Fact]
        public void ShouldUpdatePrice()
        {
            // Arrange
            var apartmentAd = A.Dummy<ApartmentAd>();
            var price = 1.6m;
            
            // Act
            apartmentAd.UpdatePrice(price);
            
            // Assert
            apartmentAd.Price.Should().Be(price);
        }
        
        [Fact]
        public void ShouldThrowExceptionWhenPriceIsLessThanMinPrice()
        {
            // Arrange
            var apartmentAd = A.Dummy<ApartmentAd>();
            var price = A.Dummy<decimal>();
            
            // Act
            Action action = () => apartmentAd.UpdatePrice(price);
            
            // Assert
            action.Should().Throw<InvalidApartmentAdException>();
        }
        
        [Fact]
        public void ShouldThrowExceptionWhenPriceIsGreaterThanMaxPrice()
        {
            // Arrange
            var apartmentAd = A.Dummy<ApartmentAd>();
            var price = A.Dummy<decimal>();
            
            // Act
            Action action = () => apartmentAd.UpdatePrice(price);
            
            // Assert
            action.Should().Throw<InvalidApartmentAdException>();
        }
        
        // Test squareMeters
        [Fact]
        public void ShouldUpdateSquareMeters()
        {
            // Arrange
            var apartmentAd = A.Dummy<ApartmentAd>();
            var squareMeters = 2;
            
            // Act
            apartmentAd.UpdateSquareMeters(squareMeters);
            
            // Assert
            apartmentAd.SquareMeters.Should().Be(squareMeters);
        }
        
        [Fact]
        public void ShouldThrowExceptionWhenSquareMetersIsLessThanMinSquareMeters()
        {
            // Arrange
            var apartmentAd = A.Dummy<ApartmentAd>();
            var squareMeters = A.Dummy<int>();
            
            // Act
            Action action = () => apartmentAd.UpdateSquareMeters(squareMeters);
            
            // Assert
            action.Should().Throw<InvalidApartmentAdException>();
        }
        
        [Fact]
        public void ShouldThrowExceptionWhenSquareMetersIsGreaterThanMaxSquareMeters()
        {
            // Arrange
            var apartmentAd = A.Dummy<ApartmentAd>();
            var squareMeters = A.Dummy<int>();
            
            // Act
            Action action = () => apartmentAd.UpdateSquareMeters(squareMeters);
            
            // Assert
            action.Should().Throw<InvalidApartmentAdException>();
        }

        [Fact]
        public void ChangeAvailabilityShouldMutateIsAvailable()
        {
            // Arrange
            var apartmentAd = A.Dummy<ApartmentAd>();

            // Act
            apartmentAd.ChangeAvailability();

            // Assert
            apartmentAd.IsAvailable.Should().BeFalse();
        }
    }
}