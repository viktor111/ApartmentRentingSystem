
namespace ApartmentRentingSystem.Domain.Models.ApartmentAds
{
    using Exceptions;
    using Common;
    
    using static ModelConstants.Rooms;

    public class Rooms : ValueObject
    {
        internal Rooms(int numberOfRooms,
            int numberOfBathrooms,
            int numberOfBedrooms,
            int numberOfBalconies)
        {
            Validate(numberOfRooms,
                numberOfBathrooms, 
                numberOfBedrooms,
                numberOfBalconies);
            
            this.NumberOfRooms = numberOfRooms;
            this.NumberOfBathrooms = numberOfBathrooms;
            this.NumberOfBedrooms = numberOfBedrooms;
            this.NumberOfBalconies = numberOfBalconies;
        }
        
        public int NumberOfRooms { get; private set; }

        public int NumberOfBathrooms { get; private set; }

        public int NumberOfBedrooms { get; private set; }

        public int NumberOfBalconies { get; private set; }
        
        private void Validate(
            int numberOfRooms, 
            int numberOfBathrooms, 
            int numberOfBedrooms,
            int numberOfBalconies)
        {
           
            ValidateNumberOfRooms(numberOfRooms);
            ValidateNumberOfBathrooms(numberOfBathrooms);
            ValidateNumberOfBedrooms(numberOfBedrooms);
            ValidateNumberOfBalconies(numberOfBalconies);
        }
        
        public Rooms UpdateNumberOfRooms(int numberOfRooms)
        {
            ValidateNumberOfRooms(numberOfRooms);
            this.NumberOfRooms = numberOfRooms;
            return this;
        }
        
        public Rooms UpdateNumberOfBathrooms(int numberOfBathrooms)
        {
            ValidateNumberOfBathrooms(numberOfBathrooms);
            this.NumberOfBathrooms = numberOfBathrooms;
            return this;
        }
        
        public Rooms UpdateNumberOfBedrooms(int numberOfBedrooms)
        {
            ValidateNumberOfBedrooms(numberOfBedrooms);
            this.NumberOfBedrooms = numberOfBedrooms;
            return this;
        }
        
        public Rooms UpdateNumberOfBalconies(int numberOfBalconies)
        {
            ValidateNumberOfBalconies(numberOfBalconies);
            this.NumberOfBalconies = numberOfBalconies;
            return this;
        }
        
        private void ValidateNumberOfRooms(int numberOfRooms)
        {
            Guard.AgainstOutOfRange<InvalidRoomsException>(
                numberOfRooms,
                MinNumberOfRooms,
                MaxNumberOfRooms,
                nameof(this.NumberOfRooms));
        }
        
        private void ValidateNumberOfBathrooms(int numberOfBathrooms)
        {
            Guard.AgainstOutOfRange<InvalidRoomsException>(
                numberOfBathrooms,
                MinNumberOfBathrooms,
                MaxNumberOfBathrooms,
                nameof(this.NumberOfBathrooms));
        }
        
        private void ValidateNumberOfBedrooms(int numberOfBedrooms)
        {
            Guard.AgainstOutOfRange<InvalidRoomsException>(
                numberOfBedrooms,
                MinNumberOfBedrooms,
                MaxNumberOfBedrooms,
                nameof(this.NumberOfBedrooms));
        }
        
        private void ValidateNumberOfBalconies(int numberOfBalconies)
        {
            Guard.AgainstOutOfRange<InvalidRoomsException>(
                numberOfBalconies,
                MinNumberOfBalconies,
                MaxNumberOfBalconies,
                nameof(this.NumberOfBalconies));
        }
    }
}