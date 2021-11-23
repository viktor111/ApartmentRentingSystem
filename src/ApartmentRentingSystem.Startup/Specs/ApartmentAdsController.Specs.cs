using ApartmentRentingSystem.Application.Features.ApartmentAds.Queries.Search;
using ApartmentRentingSystem.Web.Features;
using MyTested.AspNetCore.Mvc;
using Xunit;

namespace ApartmentRentingSystem.Startup.Specs
{
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