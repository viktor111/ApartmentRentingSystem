namespace ApartmentRentingSystem.Domain.Specifications.ApartmentAds
{
    using System;
    using System.Linq.Expressions;
    using ApartmentRentingSystem.Domain.Models.ApartmentAds;

    public class ApartmentAdOnlyAvailableSpecification : Specification<ApartmentAd>
    {
        private readonly bool onlyAvailable;

        public ApartmentAdOnlyAvailableSpecification(bool onlyAvailable)
        {
            this.onlyAvailable = onlyAvailable;
        }

        public override Expression<Func<ApartmentAd, bool>> ToExpression()
        {
            if (this.onlyAvailable)
            {
                return apartmentAd => apartmentAd.IsAvailable;
            }
            
            return apartmentAd => true;
        }
    }
}