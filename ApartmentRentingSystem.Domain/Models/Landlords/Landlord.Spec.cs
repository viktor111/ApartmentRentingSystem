using FluentAssertions;

namespace ApartmentRentingSystem.Domain.Models.Landlords
{
    using ApartmentAds;
    using FakeItEasy;
    using Xunit;

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
    }
}