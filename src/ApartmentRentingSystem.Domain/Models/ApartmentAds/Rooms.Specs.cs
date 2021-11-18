namespace ApartmentRentingSystem.Domain.Models.ApartmentAds
{
    using System;
    using Exceptions;
    using FakeItEasy;
    using FluentAssertions;
    using Xunit;
    
    using static ModelConstants.Rooms;

    public class RoomsSpecs
    {
        [Fact]
        public void ShouldUpdateNumberOfRooms()
        {
            // Arrange
            var rooms = A.Dummy<Rooms>();
            var numberOfRooms = 2;

            // Act
            rooms.UpdateNumberOfRooms(numberOfRooms);

            // Assert
            rooms.NumberOfRooms.Should().Be(numberOfRooms);
        }

        [Fact]
        public void ShouldThrowExceptionWhenNumberOfRoomsIsLessThanZero()
        {
            // Arrange
            var rooms = A.Dummy<Rooms>();
            var numberOfRooms = -1;

            // Act
            Action action = () => rooms.UpdateNumberOfRooms(numberOfRooms);

            // Assert
            action.Should().Throw<InvalidRoomsException>();
        }
        
        [Fact]
        public void ShouldThrowExceptionWhenNumberOfRoomsIsGreaterThanMax()
        {
            // Arrange
            var rooms = A.Dummy<Rooms>();
            var numberOfRooms = MaxNumberOfRooms;

            // Act
            Action action = () => rooms.UpdateNumberOfRooms(numberOfRooms + 1);

            // Assert
            action.Should().Throw<InvalidRoomsException>();
        }
        
        [Fact]
        public void ShouldUpdateNumberOfBathrooms()
        {
            // Arrange
            var rooms = A.Dummy<Rooms>();
            var numberOfBathrooms = 2;

            // Act
            rooms.UpdateNumberOfBathrooms(numberOfBathrooms);

            // Assert
            rooms.NumberOfBathrooms.Should().Be(numberOfBathrooms);
        }
        
        [Fact]
        public void ShouldThrowExceptionWhenNumberOfBathroomsIsLessThanZero()
        {
            // Arrange
            var rooms = A.Dummy<Rooms>();
            var numberOfBathrooms = -1;

            // Act
            Action action = () => rooms.UpdateNumberOfBathrooms(numberOfBathrooms);

            // Assert
            action.Should().Throw<InvalidRoomsException>();
        }
        
        [Fact]
        public void ShouldThrowExceptionWhenNumberOfBathroomsIsGreaterThanMax()
        {
            // Arrange
            var rooms = A.Dummy<Rooms>();
            var numberOfBathrooms = MaxNumberOfBathrooms;

            // Act
            Action action = () => rooms.UpdateNumberOfBathrooms(numberOfBathrooms + 1);

            // Assert
            action.Should().Throw<InvalidRoomsException>();
        }
        
        // test NumberOfBedrooms
        [Fact]
        public void ShouldUpdateNumberOfBedrooms()
        {
            // Arrange
            var rooms = A.Dummy<Rooms>();
            var numberOfBedrooms = 2;

            // Act
            rooms.UpdateNumberOfBedrooms(numberOfBedrooms);

            // Assert
            rooms.NumberOfBedrooms.Should().Be(numberOfBedrooms);
        }
        
        [Fact]
        public void ShouldThrowExceptionWhenNumberOfBedroomsIsLessThanZero()
        {
            // Arrange
            var rooms = A.Dummy<Rooms>();
            var numberOfBedrooms = -1;

            // Act
            Action action = () => rooms.UpdateNumberOfBedrooms(numberOfBedrooms);

            // Assert
            action.Should().Throw<InvalidRoomsException>();
        }
        
        [Fact]
        public void ShouldThrowExceptionWhenNumberOfBedroomsIsGreaterThanMax()
        {
            // Arrange
            var rooms = A.Dummy<Rooms>();
            var numberOfBedrooms = MaxNumberOfBedrooms;

            // Act
            Action action = () => rooms.UpdateNumberOfBedrooms(numberOfBedrooms + 1);

            // Assert
            action.Should().Throw<InvalidRoomsException>();
        }
        
        // test NumberOfBalconies
        [Fact]
        public void ShouldUpdateNumberOfBalconies()
        {
            // Arrange
            var rooms = A.Dummy<Rooms>();
            var numberOfBalconies = 2;

            // Act
            rooms.UpdateNumberOfBalconies(numberOfBalconies);

            // Assert
            rooms.NumberOfBalconies.Should().Be(numberOfBalconies);
        }
        
        [Fact]
        public void ShouldThrowExceptionWhenNumberOfBalconiesIsLessThanZero()
        {
            // Arrange
            var rooms = A.Dummy<Rooms>();
            var numberOfBalconies = -1;

            // Act
            Action action = () => rooms.UpdateNumberOfBalconies(numberOfBalconies);

            // Assert
            action.Should().Throw<InvalidRoomsException>();
        }
        
        [Fact]
        public void ShouldThrowExceptionWhenNumberOfBalconiesIsGreaterThanMax()
        {
            // Arrange
            var rooms = A.Dummy<Rooms>();
            var numberOfBalconies = MaxNumberOfBalconies;

            // Act
            Action action = () => rooms.UpdateNumberOfBalconies(numberOfBalconies + 1);

            // Assert
            action.Should().Throw<InvalidRoomsException>();
        }
    }
}