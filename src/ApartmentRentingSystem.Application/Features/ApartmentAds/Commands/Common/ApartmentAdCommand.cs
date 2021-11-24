namespace ApartmentRentingSystem.Application.Features.ApartmentAds.Commands.Common
{
    public abstract class ApartmentAdCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public string Title { get; set; } = default!;
        
        public string Country { get; set; } = default!;
        
        public string City { get; set; } = default!;
        
        public string Street { get; set; } = default!;
        
        public string Description { get; set; } = default!;
        
        public decimal Price { get; set; }
        
        public int SquareMeters { get; set; }
        
        public bool HasFurniture { get; set;}

        public bool HasParking { get; set;}

        public bool HasGarden { get; set;}

        public bool HasLift { get; set;}

        public bool HasAirConditioner { get; set;}

        public bool HasTv { get; set; }

        public bool HasInternet { get; set;}

        public bool HasPhone { get; set;}

        public bool HasWashingMachine { get; set;}

        public bool HasDishwasher { get; set;}

        public bool HasRefrigerator { get; set; }

        public bool HasMicrowave { get; set; }

        public bool HasOven { get; set; }

        public bool HasCoffeeMachine { get; set; }
        
        public int NumberOfRooms { get; set; }

        public int NumberOfBathrooms { get; set; }

        public int NumberOfBedrooms { get; set; }

        public int NumberOfBalconies { get; set; }

    }
}