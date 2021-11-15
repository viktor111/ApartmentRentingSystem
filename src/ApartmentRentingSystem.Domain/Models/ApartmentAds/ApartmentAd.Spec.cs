namespace ApartmentRentingSystem.Domain.Models.ApartmentAds
{
    using FakeItEasy;
    using FluentAssertions;
    using Xunit;
    using System;
    using Exceptions;


    public class ApartmentAdSpecs
    {
        [Fact]
        public void ChangeAvailabilityShouldMutateIsAvailable()
        {
            // Arrange
            var carAd = A.Dummy<ApartmentAd>();

            // Act
            carAd.ChangeAvailability();

            // Assert
            carAd.IsAvailable.Should().BeFalse();
        }

        [Theory]
        [InlineData("testertestertester")]
        [InlineData("qqwfqqtqwqr")]
        public void ShouldUpdateDescription(string description)
        {
            // Arrange
            var carAd = A.Dummy<ApartmentAd>();

            // Act
            carAd.UpdateDescription(description);

            // Assert
            carAd.Description.Should().Be(description);
        }

        [Theory]
        [InlineData(null)]
        public void ShouldThrowExceptionWhenUpdateDescriptionIsNull(string description)
        {
            // Arrange
            var carAd = A.Dummy<ApartmentAd>();

            // Act
            Action act = () => carAd.UpdateDescription(description);

            // Assert
            act.Should().Throw<InvalidApartmentAdException>();
        }

        [Fact]
        public void ShouldThrowExceptionWhenUpdateDescriptionExceedsMaxLength()
        {
            // Arrange
            var carAd = A.Dummy<ApartmentAd>();
            var random = new Bogus.Randomizer();

            // Act
            Action act = () => carAd.UpdateDescription(random.String(1001));

            // Assert
            act.Should().Throw<InvalidApartmentAdException>();
        }

        [Fact]
        public void ShouldThrowExceptionWhenUpdateDescriptionMinLengthIsNotMet()
        {
            // Arrange
            var carAd = A.Dummy<ApartmentAd>();

            // Act
            Action act = () => carAd.UpdateDescription("awwe");

            // Assert
            act.Should().Throw<InvalidApartmentAdException>();
        }
    }
}