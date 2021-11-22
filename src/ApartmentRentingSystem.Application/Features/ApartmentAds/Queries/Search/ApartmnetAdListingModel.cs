namespace ApartmentRentingSystem.Application.Features.ApartmentAds.Queries.Search
{
    public class ApartmnetAdListingModel
    {

        public ApartmnetAdListingModel(int id,
            string title,
            string description,
            decimal price,
            int squareMeters,
            bool isAvailable)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.Price = price;
            this.SquareMeters = squareMeters;
            this.IsAvailable = isAvailable;
        }

        public int Id { get; set; }
        
        public string Title { get; }
        
        public string Description { get;  }

        public decimal Price { get; }

        public int SquareMeters { get; }

        public bool IsAvailable { get; }
    }
}