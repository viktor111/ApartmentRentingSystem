using ApartmentRentingSystem.Application.Features.ApartmentAds.Commands.Create;
using ApartmentRentingSystem.Application.Features.ApartmentAds.Commands.Edit;

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
            return await this.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<CreateApartmentAdOutputModel>> Create(
            [FromQuery] CreateApartmentAdCommand command)
        {
            return await this.Send(command);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id, EditApartmentAdCommand command)
        {
            return await this.Send(command);
        }
    }
}