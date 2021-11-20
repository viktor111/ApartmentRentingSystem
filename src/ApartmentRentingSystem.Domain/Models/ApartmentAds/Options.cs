namespace ApartmentRentingSystem.Domain.Models.ApartmentAds
{
    using Common;

    public class Options : ValueObject
    {
        internal Options(bool hasFurniture,
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
            this.HasFurniture = hasFurniture;
            this.HasParking = hasParking;
            this.HasGarden = hasGarden;
            this.HasLift = hasLift;
            this.HasAirConditioner = hasAirConditioner;
            this.HasTv = hasTv;
            this.HasInternet = hasInternet;
            this.HasPhone = hasPhone;
            this.HasWashingMachine = hasWashingMachine;
            this.HasDishwasher = hasDishwasher;
            this.HasRefrigerator = hasRefrigerator;
            this.HasMicrowave = hasMicrowave;
            this.HasOven = hasOven;
            this.HasCoffeeMachine = hasCoffeeMachine;
        }

        private Options() { }

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