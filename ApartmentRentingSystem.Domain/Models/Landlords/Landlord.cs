namespace ApartmentRentingSystem.Domain.Models.Landlords
{
    using System.Collections.Generic;
    using Common;
    using Exceptions;
    using ApartmentAds;
    
    using static ModelConstants.Common;
    public class Landlord : Entity<int>, IAggregateRoot
    {
        private HashSet<ApartmentAd> apartmentAds;

        internal Landlord(string name, string phoneNumber)
        {
            this.Name = name;
            this.apartmentAds = new HashSet<ApartmentAd>();
        }

        public Landlord(string name)
        {
            this.Name = name;
            this.apartmentAds = new HashSet<ApartmentAd>();
        }

        public string Name { get; private set; }

        public Landlord UpdateName(string name)
        {
            this.Validate(name);
            this.Name = name;

            return this;
        }

        private void Validate(string name)
            => Guard.ForStringLength<InvalidLandlordException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
    }
}