namespace ApartmentRentingSystem.Domain.Models.ApartmentAds
{
    using System;
    using Exceptions;
    using FakeItEasy;
    using FluentAssertions;
    using Xunit;

    using static ModelConstants.Address;

    public class AddressSpecs
    {
        [Fact]
        public void ShouldUpdateCountry()
        {
            // Arrange
            var address = A.Dummy<Address>();
            var country = "Mars13";

            // Act
            address.UpdateCountry(country);

            // Assert
            address.Country.Should().Be(country);
        }

        [Fact]
        public void ShouldThrowExceptionWhenCountryIsNull()
        {
            // Arrange
            var address = A.Dummy<Address>();
            string country = String.Empty;

            // Act
            Action action = () => address.UpdateCountry(country);

            // Assert
            action.Should().Throw<InvalidAddressException>();
        }

        [Fact]
        public void ShouldThrowExceptionWhenUpdateCountryExceedsMaxLength()
        {
            // Arrange
            var address = A.Dummy<Address>();
            var random = new Bogus.Randomizer();

            // Act
            Action action = () => address.UpdateCountry(random.String(MaxCountryLength + 1));

            // Assert
            action.Should().Throw<InvalidAddressException>();
        }
        
        [Fact]
        public void ShouldThrowExceptionWhenUpdateCountryIsLessThanMinLength()
        {
            // Arrange
            var address = A.Dummy<Address>();
            var random = new Bogus.Randomizer();

            // Act
            Action action = () => address.UpdateCountry(random.String(MinCountryLength - 1));

            // Assert
            action.Should().Throw<InvalidAddressException>();
        }
        
        [Fact]
        public void ShouldUpdateCity()
        {
            // Arrange
            var address = A.Dummy<Address>();
            var city = "Mars13";

            // Act
            address.UpdateCity(city);

            // Assert
            address.City.Should().Be(city);
        }
        
        [Fact]
        public void ShouldThrowExceptionWhenCityIsNull()
        {
            // Arrange
            var address = A.Dummy<Address>();
            string city = String.Empty;

            // Act
            Action action = () => address.UpdateCity(city);

            // Assert
            action.Should().Throw<InvalidAddressException>();
        }
        
        [Fact]
        public void ShouldThrowExceptionWhenUpdateCityExceedsMaxLength()
        {
            // Arrange
            var address = A.Dummy<Address>();
            var random = new Bogus.Randomizer();

            // Act
            Action action = () => address.UpdateCity(random.String(MaxCityLength + 1));

            // Assert
            action.Should().Throw<InvalidAddressException>();
        }
        
        [Fact]
        public void ShouldThrowExceptionWhenUpdateCityIsLessThanMinLength()
        {
            // Arrange
            var address = A.Dummy<Address>();
            var random = new Bogus.Randomizer();

            // Act
            Action action = () => address.UpdateCity(random.String(MinCityLength - 1));

            // Assert
            action.Should().Throw<InvalidAddressException>();
        }
        
        [Fact]
        public void ShouldUpdateStreet()
        {
            // Arrange
            var address = A.Dummy<Address>();
            var street = "Mars13";

            // Act
            address.UpdateStreet(street);

            // Assert
            address.Street.Should().Be(street);
        }
        
        [Fact]
        public void ShouldThrowExceptionWhenStreetIsNull()
        {
            // Arrange
            var address = A.Dummy<Address>();
            string street = String.Empty;

            // Act
            Action action = () => address.UpdateStreet(street);

            // Assert
            action.Should().Throw<InvalidAddressException>();
        }
        
        [Fact]
        public void ShouldThrowExceptionWhenUpdateStreetExceedsMaxLength()
        {
            // Arrange
            var address = A.Dummy<Address>();
            var random = new Bogus.Randomizer();

            // Act
            Action action = () => address.UpdateStreet(random.String(MaxStreetLength + 1));

            // Assert
            action.Should().Throw<InvalidAddressException>();
        }
        
        [Fact]
        public void ShouldThrowExceptionWhenUpdateStreetIsLessThanMinLength()
        {
            // Arrange
            var address = A.Dummy<Address>();
            var random = new Bogus.Randomizer();

            // Act
            Action action = () => address.UpdateStreet(random.String(MinStreetLength - 1));

            // Assert
            action.Should().Throw<InvalidAddressException>();
        }
    }
}