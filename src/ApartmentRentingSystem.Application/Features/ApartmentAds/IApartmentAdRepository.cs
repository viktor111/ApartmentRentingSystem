namespace ApartmentRentingSystem.Application.Features.ApartmentAds
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Contracts;
    using Queries.Search;
    using Domain.Models.ApartmentAds;

    public interface IApartmentAdRepository : IRepository<ApartmentAd>
    {
        Task<IEnumerable<ApartmnetAdListingModel>> GetApartmentAdListings(string? title = default,
            CancellationToken cancellationToken = default);
        
        Task<ApartmentAd> Find(int id, 
            CancellationToken cancellationToken = default);

        Task<int> Total(CancellationToken cancellationToken = default);
    }
}