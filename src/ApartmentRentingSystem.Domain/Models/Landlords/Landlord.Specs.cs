namespace ApartmentRentingSystem.Domain.Models.Landlords
{
    using ApartmentAds;
    using FakeItEasy;
    using Xunit;
    using System;
    using Exceptions;
    using FluentAssertions;
    using static ModelConstants.Common;

    public class LandlordSpecs
    {
        [Fact]
        public void ShouldSaveApartmentAd()
        {
            //Arrange
            var landlord = A.Dummy<Landlord>();
            var apartmentAd = A.Dummy<ApartmentAd>();

            //Act
            landlord.AddApartmentAd(apartmentAd);

            //Assert
            landlord.ApartmentAds.Should().Contain(apartmentAd);
        }

        [Theory]
        [InlineData(null)]
        public void ShouldThrowExceptionWhenNameIsNull(string name)
        {
            //Arrange
            var landlord = A.Dummy<Landlord>();

            //Act
            Action act = () => landlord.UpdateName(name);

            //Assert
            act.Should().Throw<InvalidLandlordException>();
        }

        [Fact]
        public void ShouldUpdateName()
        {
            //Arrange
            var landlord = A.Dummy<Landlord>();
            var newName = "Testname";

            //Act
            landlord.UpdateName(newName);

            //Assert
            landlord.Name.Should().Be(newName);
        }

        [Fact]
        public void ShouldThrowExceptionWhenNameIsTooShort()
        {
            //Arrange
            var landlord = A.Dummy<Landlord>();
            var newName = "T";

            //Act
            Action act = () => landlord.UpdateName(newName);

            //Assert
            act.Should().Throw<InvalidLandlordException>();
        }

        // test name max
        [Fact]
        public void ShouldThrowExceptionWhenNameIsTooLong()
        {
            //Arrange
            var landlord = A.Dummy<Landlord>();
            var random = new Bogus.Randomizer();


            //Act
            Action act = () => landlord.UpdateName(random.String(MaxNameLength + 1));

            //Assert
            act.Should().Throw<InvalidLandlordException>();
        }
    }
}