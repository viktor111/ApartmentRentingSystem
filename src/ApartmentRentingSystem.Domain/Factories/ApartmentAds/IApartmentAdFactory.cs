namespace ApartmentRentingSystem.Domain.Factories.ApartmentAds
{
    using Models.ApartmentAds;

    public interface IApartmentAdFactory : IFactory<ApartmentAd>
    {
        IApartmentAdFactory WithTitle(string title);

        IApartmentAdFactory WithAddress(string address);
        
        IApartmentAdFactory WithDescription(string description);
        
        IApartmentAdFactory WithPrice(decimal price);

        IApartmentAdFactory WithSquareMeters(int squareMeters);

        IApartmentAdFactory WithOptions(bool hasFurniture,
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
            bool hasCoffeeMachine);
        
        IApartmentAdFactory WithOptions(Options options);
        
        IApartmentAdFactory WithRooms(int numberOfRooms,
            int numberOfBathrooms,
            int numberOfBedrooms,
            int numberOfBalconies);
        
        IApartmentAdFactory WithRooms(Rooms rooms);
        
        
    }
}