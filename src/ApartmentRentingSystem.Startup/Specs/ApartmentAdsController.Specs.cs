namespace ApartmentRentingSystem.Startup.Specs
{
    using Application.Features.ApartmentAds.Queries.Search;
    using Web.Features;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class ApartmentAdsControllerSpecs
    {
        [Fact]
        public void SearchShouldHaveCorrectAttributes()
        {
            MyController<ApartmentAdsController>
                .Calling(c => c.Search(With.Default<SearchApartmentAdsQuery>()))
                .ShouldHave()
                .ActionAttributes(attr => attr
                    .RestrictingForHttpMethod(HttpMethod.Get));
        }
    }
}