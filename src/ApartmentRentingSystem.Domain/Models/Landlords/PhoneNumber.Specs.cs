namespace ApartmentRentingSystem.Domain.Models.Landlords
{
    using System;
    using Exceptions;
    using FakeItEasy;
    using FluentAssertions;
    using Xunit;
    
    using static ModelConstants.PhoneNumber;
    
    public class PhoneNumberSpecs
    {
        [Fact]
        public void ShouldUpdateCountryCode()
        {
            // Arrange
            var phoneNumber = A.Dummy<PhoneNumber>();
            var countryCode = "+111";
            
            // Act
            phoneNumber.UpdateCountryCode(countryCode);
            
            // Assert
            phoneNumber.CountryCode.Should().Be(countryCode);
        }
        
        [Fact]
        public void ShouldThrowExceptionWhenCountryCodeIsNull()
        {
            // Arrange
            var phoneNumber = A.Dummy<PhoneNumber>();
            string countryCode = string.Empty;
            
            // Act
            Action action = () => phoneNumber.UpdateCountryCode(countryCode);
            
            // Assert
            action.Should().Throw<InvalidPhoneNumberException>();
        }

        [Fact]
        public void ShouldThrowExceptionWhenUpdateCountryCodeExceedsMaxLength()
        {
            // Arrange
            var phoneNumber = A.Dummy<PhoneNumber>();
            var random = new Bogus.Randomizer();

            // Act
            Action action = () => phoneNumber.UpdateCountryCode(random.String(MaxCountryCodeLength + 1));
            
            // Assert
            action.Should().Throw<InvalidPhoneNumberException>();
        }

        [Fact]
        public void ShouldThrowExceptionWhenUpdateCountryCodeIsLessThanMinLength()
        {
            // Arrange
            var phoneNumber = A.Dummy<PhoneNumber>();
            var random = new Bogus.Randomizer();

            // Act
            Action action = () => phoneNumber.UpdateCountryCode(random.String(MinCountryCodeLength - 1));
            
            // Assert
            action.Should().Throw<InvalidPhoneNumberException>();
        }
        
        [Fact]
        public void ShouldUpdateNumber()
        {
            // Arrange
            var phoneNumber = A.Dummy<PhoneNumber>();
            var number = "123456789";
            
            // Act
            phoneNumber.UpdateNumber(number);
            
            // Assert
            phoneNumber.Number.Should().Be(number);
        }
        
        [Fact]
        public void ShouldThrowExceptionWhenNumberIsNull()
        {
            // Arrange
            var phoneNumber = A.Dummy<PhoneNumber>();
            string number = string.Empty;
            
            // Act
            Action action = () => phoneNumber.UpdateNumber(number);
            
            // Assert
            action.Should().Throw<InvalidPhoneNumberException>();
        }
        
        [Fact]
        public void ShouldThrowExceptionWhenNumberIsLessThanMinLength()
        {
            // Arrange
            var phoneNumber = A.Dummy<PhoneNumber>();
            var random = new Bogus.Randomizer();

            // Act
            Action action = () => phoneNumber.UpdateNumber(random.String(MinPhoneNumberLength - 1));
            
            // Assert
            action.Should().Throw<InvalidPhoneNumberException>();
        }
        
        [Fact]
        public void ShouldThrowExceptionWhenNumberIsGreaterThanMaxLength()
        {
            // Arrange
            var phoneNumber = A.Dummy<PhoneNumber>();
            var random = new Bogus.Randomizer();

            // Act
            Action action = () => phoneNumber.UpdateNumber(random.String(MaxPhoneNumberLength + 1));
            
            // Assert
            action.Should().Throw<InvalidPhoneNumberException>();
        }
    }
}