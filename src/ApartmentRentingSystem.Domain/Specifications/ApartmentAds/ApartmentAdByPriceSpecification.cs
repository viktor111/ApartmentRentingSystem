namespace ApartmentRentingSystem.Domain.Specifications.ApartmentAds
{
    using System;
    using System.Linq.Expressions;
    using Domain.Models.ApartmentAds;

    public class ApartmentAdByPriceSpecification : Specification<ApartmentAd>
    {
        private readonly decimal minPrice;
        private readonly decimal maxPrice;

        public ApartmentAdByPriceSpecification(
            decimal? minPrice = default,
            decimal? maxPrice = decimal.MaxValue)
        {
            this.minPrice = minPrice ?? default;
            this.maxPrice = maxPrice ?? decimal.MaxValue;
        }

        public override Expression<Func<ApartmentAd, bool>> ToExpression()
        {
            return apartmentAd => this.minPrice < apartmentAd.Price && apartmentAd.Price < this.maxPrice;
        }
    }
}