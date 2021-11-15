namespace ApartmentRentingSystem.Domain.Models.ApartmentAds
{
    using Common;
    using Exceptions;


    public class Options : ValueObject
    {
        public Options(bool hasFurniture,
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
        }

        public bool HasFurniture { get; }

        public bool HasParking { get; }

        public bool HasGarden { get; }

        public bool HasLift { get; }

        public bool HasAirConditioner { get; }

        public bool HasTv { get; }

        public bool HasInternet { get; }

        public bool HasPhone { get; }

        public bool HasWashingMachine { get; }

        public bool HasDishwasher { get; }

        public bool HasRefrigerator { get; }

        public bool HasMicrowave { get; }

        public bool HasOven { get; }

        public bool HasCoffeeMachine { get; }
    }
}