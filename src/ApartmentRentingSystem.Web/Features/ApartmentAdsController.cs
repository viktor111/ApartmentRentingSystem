namespace ApartmentRentingSystem.Web.Features
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Application.Features.ApartmentAds.Queries.Search;

    [ApiController]
    [Route("api/[controller]")]
    public class ApartmentAdsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<SearchApartmentAdsOutputModel>> Get([FromQuery] SearchApartmentAdsQuery query)
        {
            return await this.Mediator.Send(query);
        }
    }
}