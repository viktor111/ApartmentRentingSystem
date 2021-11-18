namespace ApartmentRentingSystem.Domain.Models.Landlords
{
    using System.Collections.Generic;
    using Common;
    using Exceptions;
    using ApartmentAds;
    using static ModelConstants.Common;
    using System.Linq;

    public class Landlord : Entity<int>, IAggregateRoot
    {
        private HashSet<ApartmentAd> apartmentAds;

        internal Landlord(string name, PhoneNumber phoneNumber)
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.apartmentAds = new HashSet<ApartmentAd>();
        }

        public Landlord(string name)
        {
            this.Name = name;
            this.PhoneNumber = default!;
            this.apartmentAds = new HashSet<ApartmentAd>();
        }

        public string Name { get; private set; }

        public PhoneNumber PhoneNumber { get; private set; }

        public Landlord UpdateName(string name)
        {
            this.Validate(name);
            this.Name = name;

            return this;
        }

        public Landlord UpdatePhoneNumber(PhoneNumber phoneNumber)
        {
            this.PhoneNumber = phoneNumber;

            return this;
        }

        public IReadOnlyCollection<ApartmentAd> ApartmentAds => this.apartmentAds.ToList().AsReadOnly();

        public void AddApartmentAd(ApartmentAd apartmentAd)
        {
            this.apartmentAds.Add(apartmentAd);
        }

        private void Validate(string name)
        {
            Guard.ForStringLength<InvalidLandlordException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
        }
    }
}