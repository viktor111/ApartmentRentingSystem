namespace ApartmentRentingSystem.Application.Features.ApartmentAds.Queries.Search
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class SearchApartmentAdsQuery : IRequest<SearchApartmentAdsOutputModel>
    {
        public string? Title { get; set; }

        public class SearchCarAdsQueryHandler : IRequestHandler<SearchApartmentAdsQuery, SearchApartmentAdsOutputModel>
        {
            private readonly IApartmentAdRepository apartmentAdRepository;

            public SearchCarAdsQueryHandler(IApartmentAdRepository apartmentAdRepository)
                => this.apartmentAdRepository = apartmentAdRepository;

            public async Task<SearchApartmentAdsOutputModel> Handle(
                SearchApartmentAdsQuery request,
                CancellationToken cancellationToken)
            {
                var carAdListings = await this.apartmentAdRepository.GetApartmentAdListings(
                    request.Title,
                    cancellationToken);

                var totalCarAds = await this.apartmentAdRepository.Total(cancellationToken);

                return new SearchApartmentAdsOutputModel(carAdListings, totalCarAds);
            }
        }
    }
}