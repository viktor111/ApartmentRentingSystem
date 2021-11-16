using ApartmentRentingSystem.Domain.Models.ApartmentAds;
using FluentAssertions;
using Xunit;

namespace ApartmentRentingSystem.Domain.Common
{
    public class ValueObjectSpecs
    {
        [Fact]
        public void ValueObjectsWithEqualPropertiesShouldBeEqual()
        {
            // Arrange
            var first = new Rooms(1, 2, 3, 4);
            var second = new Rooms(1, 2, 3, 4);

            // Act
            var result = first == second;

            // Arrange
            result.Should().BeTrue();
        }

        [Fact]
        public void ValueObjectsWithDifferentPropertiesShouldNotBeEqual()
        {
            // Arrange
            var first = new Rooms(1,1,1,1);
            var second = new Rooms(2,2,2,2);

            // Act
            var result = first == second;

            // Arrange
            result.Should().BeFalse();
        }
    }
}