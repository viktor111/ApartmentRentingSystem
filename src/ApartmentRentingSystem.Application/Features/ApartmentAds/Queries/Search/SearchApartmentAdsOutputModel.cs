namespace ApartmentRentingSystem.Application.Features.ApartmentAds.Queries.Search
{
    using System.Collections.Generic;

    public class SearchApartmentAdsOutputModel
    {
        internal SearchApartmentAdsOutputModel(IEnumerable<ApartmnetAdListingModel> carAds, int total)
        {
            this.ApartmnetAds = carAds;
            this.Total = total;
        }

        public IEnumerable<ApartmnetAdListingModel> ApartmnetAds { get; }

        public int Total { get; }
    }
}