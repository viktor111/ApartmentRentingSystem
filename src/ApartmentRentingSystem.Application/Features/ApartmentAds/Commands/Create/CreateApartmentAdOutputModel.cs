namespace ApartmentRentingSystem.Application.Features.ApartmentAds.Commands.Create
{
    public class CreateApartmentAdOutputModel
    {
        public CreateApartmentAdOutputModel(int apartmentId)
        {
            this.ApartmentId = apartmentId;
        }
        
        public int ApartmentId { get; }
    }
}