using ApartmentRentingSystem.Application.Features.ApartmentAds.Commands.Create;

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
        public async Task<ActionResult<SearchApartmentAdsOutputModel>> Search([FromQuery] SearchApartmentAdsQuery query)
        {
            return await this.Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<CreateApartmentAdOutputModel>> Create(
            [FromQuery] CreateApartmentAdCommand command)
        {
            return await this.Mediator.Send(command);
        }
    }
}