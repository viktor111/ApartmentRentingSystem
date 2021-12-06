using System.Threading;
using ApartmentRentingSystem.Domain.Models.Landlords;
using ApartmentRentingSystem.Domain.Specifications.ApartmentAds;
using ApartmentRentingSystem.Domain.Specifications.Landlords;

namespace ApartmentRentingSystem.Application.Features.ApartmentAds.Queries.Common
{
    using Domain.Models.ApartmentAds;
    using Domain.Specifications;

    public abstract class ApartmentAdsQuery
    {
        private const int CarAdsPerPage = 10;

        public int? MinSquareMeters { get; set; }

        public int? MaxSquareMeters { get; set; }

        public string? Landlord { get; set; }

        public decimal? Price { get; set; }
        
        public decimal? MinPrice { get; set; }
        
        public decimal? MaxPrice { get; set; }
        

        public string? SortBy { get; set; }
        

        public string? Order { get; set; }
        

        public int Page { get; set; } = 1;


        public abstract class ApartmentAdsQueryHandler
        {
            private readonly IApartmentAdRepository apartmentAdRepository;

            protected ApartmentAdsQueryHandler(IApartmentAdRepository apartmentAdRepository)
            {
                this.apartmentAdRepository = apartmentAdRepository;
            }

            private Specification<ApartmentAd> GetApartmentAdSpecification(ApartmentAdsQuery request,
                bool onlyAvailable)
            {
                return new ApartmentAdByPriceSpecification(request.MinPrice, request.MaxPrice)
                    .And(new ApartmentAdBySquareMetersSpecification(request.MinSquareMeters, request.MaxSquareMeters))
                    .And(new ApartmentAdOnlyAvailableSpecification(onlyAvailable));
            }

            private Specification<Landlord> GetLandlordSpecification(ApartmentAdsQuery request, int? landlordId)
            {
                return new LandlordByIdSpecification(landlordId)
                    .And(new LandlordByNameSpecification(request.Landlord));
            }
        }
    }
}