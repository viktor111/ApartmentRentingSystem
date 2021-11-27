namespace ApartmentRentingSystem.Web.Features
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Application.Features.ApartmentAds.Queries.Search;
    using Application.Features.ApartmentAds.Commands.Create;
    using Application.Features.ApartmentAds.Commands.Edit;

    [ApiController]
    [Route("api/[controller]")]
    public class ApartmentAdsController : ApiController
    {
        [HttpGet(nameof(Search))]
        public async Task<ActionResult<SearchApartmentAdsOutputModel>> Search([FromQuery] SearchApartmentAdsQuery query)
        {
            return await this.Send(query);
        }

        [HttpPost(nameof(Create))]
        public async Task<ActionResult<CreateApartmentAdOutputModel>> Create([FromBody]CreateApartmentAdCommand command)
        {
            return await this.Send(command);
        }

        [HttpPost(nameof(Edit))]
        public async Task<ActionResult> Edit(int id, EditApartmentAdCommand command)
        {
            return await this.Send(command);
        }
    }
}