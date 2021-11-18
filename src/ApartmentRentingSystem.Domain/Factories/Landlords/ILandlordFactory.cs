namespace ApartmentRentingSystem.Domain.Factories.Landlords
{
    using Models.Landlords;

    public interface ILandlordFactory : IFactory<Landlord>
    {
        public ILandlordFactory WithName(string name);

        public ILandlordFactory WithPhoneNumber(string countryCode, string phoneNumber);

        public ILandlordFactory WithPhoneNumber(PhoneNumber phoneNumber);
    }
}