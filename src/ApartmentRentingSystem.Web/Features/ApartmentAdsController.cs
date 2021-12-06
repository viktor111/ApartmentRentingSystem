using ApartmentRentingSystem.Domain.Factories.ApartmentAds;
using ApartmentRentingSystem.Domain.Models.ApartmentAds;

namespace ApartmentRentingSystem.Web.Features
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Application.Features.ApartmentAds.Queries.Search;
    using Application.Features.ApartmentAds.Commands.Create;
    using Application.Features.ApartmentAds.Commands.Edit;

    [Route("api/[controller]")]
    public class ApartmentAdsController : ApiController
    {
        [HttpGet(nameof(Search))]
        public async Task<ActionResult<SearchApartmentAdsOutputModel>> Search([FromQuery] SearchApartmentAdsQuery query)
        {
            return await this.Send(query);
        }

        [HttpPost(nameof(Create))]
        public async Task<ActionResult<CreateApartmentAdOutputModel>> Create(CreateApartmentAdCommand command)
        {
            return await this.Send(command);
        }

        [HttpPost(nameof(Edit))]
        public async Task<ActionResult> Edit(int id, EditApartmentAdCommand command)
        {
            return await this.Send(command);
        }

        [HttpPost(nameof(Test))]
        public ActionResult Test([FromBody]decimal price)
        {
            var req = HttpContext.Request;
            
            return Ok();
        }
    }
}