namespace ApartmentRentingSystem.Application.Features.Identity
{
    using Domain.Models.Landlords;

    public interface IUser
    {
        void BecomeLandlord(Landlord landlord);
    }
}