namespace ApartmentRentingSystem.Domain.Models.ApartmentAds
{
    using Common;
    using Exceptions;
    
    using static ModelConstants.ApartmentAds;

    public class ApartmentAd : Entity<int>, IAggregateRoot
    {
        internal ApartmentAd(
            string title,
            Address address,
            string description,
            decimal price,
            int squareMeters,
            Options options,
            Rooms rooms,
            bool isAvailable)
        {
            Validate(title, 
                description, 
                price, 
                squareMeters);
            
            this.Title = title;
            this.Address = address;
            this.Description = description;
            this.Price = price;
            this.SquareMeters = squareMeters;
            this.Options = options;
            this.Rooms = rooms;
            this.IsAvailable = isAvailable;
        }
        
        private ApartmentAd(
            string title,
            string description,
            decimal price,
            int squareMeters,
            bool isAvailable)
        {
            this.Title = title;
            this.Description = description;
            this.Price = price;
            this.SquareMeters = squareMeters;
            this.IsAvailable = isAvailable;

            this.Address = default!;
            this.Options = default!;
            this.Rooms = default!;
        }

        public string Title { get; set; }

        public Address Address { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public int SquareMeters { get; private set; }

        public Options Options { get; private set; }
        
        public Rooms Rooms { get; private set; }

        public bool IsAvailable { get; private set; }

        public ApartmentAd UpdateTitle(string title)
        {
            ValidateTitle(title);
            this.Title = title;
            return this;
        }
        
        public ApartmentAd UpdateAddress(string country, string city, string street)
        {
            this.Address = new Address(country, city, street);
            return this;
        }

        public ApartmentAd UpdateDescription(string description)
        {
            ValidateDescription(description);
            this.Description = description;
            return this;
        }
        
        public ApartmentAd UpdatePrice(decimal price)
        {
            ValidatePrice(price);
            this.Price = price;
            return this;
        }
        
        public ApartmentAd UpdateSquareMeters(int squareMeters)
        {
            ValidateSquareMeters(squareMeters);
            this.SquareMeters = squareMeters;
            return this;
        }
        
        public ApartmentAd UpdateOptions(
            bool hasFurniture,
            bool hasParking,
            bool hasGarden,
            bool hasLift,
            bool hasAirConditioner,
            bool hasTv,
            bool hasInternet,
            bool hasPhone,
            bool hasWashingMachine,
            bool hasDishwasher,
            bool hasRefrigerator,
            bool hasMicrowave,
            bool hasOven,
            bool hasCoffeeMachine)
        {
            this.Options = new Options(hasFurniture,
                hasParking,
                hasGarden,
                hasLift,
                hasAirConditioner,
                hasTv,
                hasInternet,
                hasPhone,
                hasWashingMachine,
                hasDishwasher,
                hasRefrigerator,
                hasMicrowave,
                hasOven,
                hasCoffeeMachine);
            
            return this;
        }
        
        public ApartmentAd UpdateRooms(
            int numberOfRooms,
            int numberOfBathrooms,
            int numberOfBedrooms,
            int numberOfBalconies)
        {
            this.Rooms = new Rooms(
                numberOfRooms,
                numberOfBathrooms,
                numberOfBedrooms,
                numberOfBalconies);
            
            return this;
        }
        
        public ApartmentAd ChangeAvailability()
        {
            this.IsAvailable = !this.IsAvailable;
            return this;
        }

        private void Validate(string title, 
            string description, 
            decimal price, 
            int squareMeters)
        {
            ValidateTitle(title);
            ValidateDescription(description);
            ValidatePrice(price);
            ValidateSquareMeters(squareMeters);
        }

        private void ValidateTitle(string title)
        {
            Guard.AgainstEmptyString<InvalidApartmentAdException>(
                title,
                nameof(this.Title));

            Guard.ForStringLength<InvalidApartmentAdException>(
                title,
                MinTitleLength,
                MaxTitleLength,
                nameof(this.Title));
        }

        private void ValidateDescription(string description)
        {
            Guard.AgainstEmptyString<InvalidApartmentAdException>(
                description,
                nameof(this.Description));

            Guard.ForStringLength<InvalidApartmentAdException>(
                description,
                MinDescriptionLength,
                MaxDescriptionLength,
                nameof(this.Description));
        }
        
        private void ValidatePrice(decimal price)
        {
            Guard.AgainstOutOfRange<InvalidApartmentAdException>(
                price,
                MinPrice,
                MaxPrice,
                nameof(this.Price));
        }
        
        private void ValidateSquareMeters(int squareMeters)
        {
            Guard.AgainstOutOfRange<InvalidApartmentAdException>(
                squareMeters,
                MinSquareMeters,
                MaxSquareMeters,
                nameof(this.SquareMeters));
        }
    }
}