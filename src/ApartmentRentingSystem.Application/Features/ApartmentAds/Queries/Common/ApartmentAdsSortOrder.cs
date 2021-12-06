namespace ApartmentRentingSystem.Application.Features.ApartmentAds.Queries.Common
{
    using System;
    using System.Linq.Expressions;
    using Application.Common;
    using Domain.Models.ApartmentAds;


    public class ApartmentAdsSortOrder : SortOrder<ApartmentAd>
    {
        public ApartmentAdsSortOrder(string? sortBy, string? order) : base(sortBy, order)
        {
        }

        public override Expression<Func<ApartmentAd, object>> ToExpression()
        {
            return this.SortBy switch
            {
                "price" => apartmentAd => apartmentAd.Price,
                "squareMeters" => apartmentAd => apartmentAd.SquareMeters,
                _ => apartmentAd => apartmentAd.Title,
            };
        }
    }
}