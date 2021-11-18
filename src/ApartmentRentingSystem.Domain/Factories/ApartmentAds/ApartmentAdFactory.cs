namespace ApartmentRentingSystem.Domain.Factories.ApartmentAds
{
    using Exceptions;
    using Models.ApartmentAds;

    public class ApartmentAdFactory : IApartmentAdFactory
    {
        private string apartmentAdTitle = default!;
        private string apartmentAdAddress = default!;
        private string apartmentAdDescription = default!;
        private decimal apartmentAdPrice = default!;
        private int apartmentAdSquareMeters = default!;
        private Options apartmentAdOptions = default!;
        private Rooms apartmentAdRooms = default!;

        private bool optionsSet = false;
        private bool roomsSet = false;

        public IApartmentAdFactory WithTitle(string title)
        {
            this.apartmentAdTitle = title;
            return this;
        }

        public IApartmentAdFactory WithAddress(string address)
        {
            this.apartmentAdAddress = address;
            return this;
        }

        public IApartmentAdFactory WithDescription(string description)
        {
            this.apartmentAdDescription = description;
            return this;
        }

        public IApartmentAdFactory WithPrice(decimal price)
        {
            this.apartmentAdPrice = price;
            return this;
        }

        public IApartmentAdFactory WithSquareMeters(int squareMeters)
        {
            this.apartmentAdSquareMeters = squareMeters;
            return this;
        }

        public IApartmentAdFactory WithOptions(bool hasFurniture,
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
            this.apartmentAdOptions = new Options(hasFurniture,
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
            this.optionsSet = true;
            return this;
        }

        public IApartmentAdFactory WithOptions(Options options)
        {
            this.apartmentAdOptions = options;
            this.optionsSet = true;
            return this;
        }

        public IApartmentAdFactory WithRooms(int numberOfRooms,
            int numberOfBathrooms,
            int numberOfBedrooms,
            int numberOfBalconies)
        {
            this.apartmentAdRooms = new Rooms(numberOfRooms,
                numberOfBathrooms,
                numberOfBedrooms,
                numberOfBalconies);
            this.roomsSet = true;
            return this;
        }

        public IApartmentAdFactory WithRooms(Rooms rooms)
        {
            this.apartmentAdRooms = rooms;
            this.roomsSet = true;
            return this;
        }

        public ApartmentAd Build()
        {
            if (!this.optionsSet || !this.roomsSet)
            {
                throw new InvalidApartmentAdException("Apartment ad must have options and rooms set.");
            }

            return new ApartmentAd(this.apartmentAdTitle,
                this.apartmentAdAddress,
                this.apartmentAdDescription,
                this.apartmentAdPrice,
                this.apartmentAdSquareMeters,
                this.apartmentAdOptions,
                this.apartmentAdRooms,
                true);
        }
    }
}