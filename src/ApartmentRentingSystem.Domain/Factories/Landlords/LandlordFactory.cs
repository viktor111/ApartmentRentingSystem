namespace ApartmentRentingSystem.Domain.Factories.Landlords
{
    using Exceptions;
    using Models.Landlords;
    
    public class LandlordFactory : ILandlordFactory
    {
        private string landlordName = default!;
        private PhoneNumber landlordPhoneNumber = default!;

        private bool phoneNumberIsSet = false;

        public ILandlordFactory WithName(string name)
        {
            this.landlordName = name;
            return this;
        }

        public ILandlordFactory WithPhoneNumber(string countryCode, string phoneNumber)
        {
            this.landlordPhoneNumber = new PhoneNumber(countryCode, phoneNumber);
            this.phoneNumberIsSet = true;
            return this;
        }

        public ILandlordFactory WithPhoneNumber(PhoneNumber phoneNumber)
        {
            this.landlordPhoneNumber = phoneNumber;
            this.phoneNumberIsSet = true;
            return this;
        }

        public Landlord Build()
        {
            if (!this.phoneNumberIsSet)
            {
                throw new InvalidLandlordException("Phone number is not set");
            }

            return new Landlord(this.landlordName, this.landlordPhoneNumber);
        }
    }
}