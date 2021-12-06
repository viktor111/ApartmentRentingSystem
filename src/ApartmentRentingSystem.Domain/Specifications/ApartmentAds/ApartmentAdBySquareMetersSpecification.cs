namespace ApartmentRentingSystem.Domain.Specifications.ApartmentAds
{
    using System;
    using System.Linq.Expressions;
    using Domain.Models.ApartmentAds;

    public class ApartmentAdBySquareMetersSpecification : Specification<ApartmentAd>
    {
        private readonly int minSquareMeters;
        private readonly int maxSquareMeters;

        public ApartmentAdBySquareMetersSpecification(int? minSquareMeters = default, int? maxSquareMeters =int.MaxValue)
        {
            this.minSquareMeters = minSquareMeters ?? default;
            this.maxSquareMeters = maxSquareMeters ?? int.MaxValue;
        }

        public override Expression<Func<ApartmentAd, bool>> ToExpression()
        {
            return apartmentAd => this.minSquareMeters < apartmentAd.SquareMeters &&
                                  apartmentAd.SquareMeters < this.maxSquareMeters;
        }
    }
}