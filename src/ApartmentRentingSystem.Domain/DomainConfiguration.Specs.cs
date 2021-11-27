namespace ApartmentRentingSystem.Domain
{
    using Factories.ApartmentAds;
    using Factories.Landlords;
    using FluentAssertions;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class DomainConfigurationSpecs
    {
        [Fact]
        public void AddDomainShouldRegisterFactories()
        {
            // Arrange
            var serviceCollection = new ServiceCollection();

            // Act
            var services = serviceCollection
                .AddDomain()
                .BuildServiceProvider();

            // Assert
            services
                .GetService<IApartmentAdFactory>()
                .Should()
                .NotBeNull();

            services
                .GetService<ILandlordFactory>()
                .Should()
                .NotBeNull();
        }
    }
}
