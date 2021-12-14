namespace ApartmentRentingSystem.Web.Features
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Application.Features.ApartmentAds.Queries.Search;
    using Application.Features.ApartmentAds.Commands.Create;
    using Application.Features.ApartmentAds.Commands.Edit;
    using ApartmentRentingSystem.Application.Features.ApartmentAds.Commands.Delete;
    using Microsoft.AspNetCore.Authorization;

    [Route("api/[controller]")]
    public class ApartmentAdsController : ApiController
    {
        [HttpGet(nameof(Search))]
        public async Task<ActionResult<SearchApartmentAdsOutputModel>> Search([FromQuery] SearchApartmentAdsQuery query)
        {
            return await this.Send(query);
        }

        [Authorize]
        [HttpPost(nameof(Create))]
        public async Task<ActionResult<CreateApartmentAdOutputModel>> Create(CreateApartmentAdCommand command)
        {
            return await this.Send(command);
        }

        [Authorize]
        [HttpPost(nameof(Edit))]
        public async Task<ActionResult> Edit(int id, EditApartmentAdCommand command)
        {
            return await this.Send(command);
        }

        [Authorize]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id, DeleteApartmentAdCommand command)
        {
            return await this.Send(command);
        }
    }
}